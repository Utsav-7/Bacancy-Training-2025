using System.Collections.Generic;
using System.ComponentModel;
using System.Net.NetworkInformation;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using Castle.Core.Resource;
using EFCore_Day_4_Loading_Types.DBContext;
using EFCore_Day_4_Loading_Types.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EFCore_Day_4_Loading_Types.Controllers
{
    public class ExplicitController : Controller
    {
        private readonly AppDBContext _dbContext;
        public ExplicitController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Write a code snippet that retrieves a Customer and explicitly loads their Orders only if the customer’s CreatedDate is within the past year.
        [HttpGet("Explicit/GetCustByRecentOrder")]
        public async Task<IActionResult> GetCustomerWithRecentOrders(int customerId)
        {
            var customer = await _dbContext.customers.FindAsync(customerId);

            if (customer == null)
                return NotFound("Customer not found");

            // Explicitly Load Orders if any Order was placed within the past year
            bool hasRecentOrders = await _dbContext.orders
                                                   .AnyAsync(o => o.CustomerId == customerId && o.OrderDate >= DateTime.UtcNow.AddYears(-1));

            if (hasRecentOrders)
            {
                await _dbContext.Entry(customer)
                                .Collection(c => c.orders)
                                .LoadAsync();
            }

            Console.WriteLine($"Customer: {customer.Name}, Email: {customer.Email}");

            foreach (var order in customer.orders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate}");
            }
            return Ok();
        }

        //Write a LINQ query that retrieves Orders without related OrderProducts but allows users to explicitly load OrderProducts on demand.Print the result.
        [HttpGet("Explicit/GetOrdersWithoutOrderProducts")]
        public async Task<IActionResult> GetOrdersWithoutOrderProducts()
        {
            var orders = await _dbContext.orders.ToListAsync(); // Fetch orders without OrderProducts

            Console.WriteLine("Orders fetched. OrderProducts not loaded yet.");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate}");

                // Load OrderProducts explicitly if requOested
                await _dbContext.Entry(order)
                                .Collection(o => o.orderProduct)
                                .LoadAsync();

                Console.WriteLine($"  Loaded {order.orderProduct.Count} OrderProducts.");
            }
            return Ok();
        }


        //Using explicit loading, write a method that retrieves Products and conditionally loads their associated Orders if the product’s Stock is below 10.
        [HttpGet("Explicit/GetProductsWithLowStockOrders")]
        public async Task<IActionResult> GetProductsWithLowStockOrders()
        {
            var products = await _dbContext.products.ToListAsync(); // Fetch all products

            foreach (var product in products)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Stock: {product.Stock}");

                if (product.Stock < 10)  // Load Orders only for low stock products
                {
                    await _dbContext.Entry(product)
                                    .Collection(p => p.orderProduct)
                                    .LoadAsync();

                    Console.WriteLine($"  Loaded {product.orderProduct.Count} associated Orders.");
                }
            }
            return Ok();
        }

        //Write a query that first retrieves Customers eagerly with their Orders, and then uses explicit loading to load OrderProducts for those orders.
        [HttpGet("Explicit/GetCustomersWithOrdersAndOrderProducts")]
        public async Task<IActionResult> GetCustomersWithOrdersAndOrderProducts()
        {
            var customers = await _dbContext.customers
                                            .Include(c => c.orders)  // Eager loading Orders
                                            .ToListAsync();

            Console.WriteLine("Customers with Orders fetched. OrderProducts not loaded yet.");

            foreach (var customer in customers)
            {
                Console.WriteLine($"Customer: {customer.Name}, Email: {customer.Email}");

                foreach (var order in customer.orders)
                {
                    Console.WriteLine($"  Order ID: {order.OrderId}, Date: {order.OrderDate}");

                    // Load OrderProducts explicitly
                    await _dbContext.Entry(order)
                                    .Collection(o => o.orderProduct)
                                    .LoadAsync();

                    Console.WriteLine($"Loaded {order.orderProduct.Count} OrderProducts.");
                }
            }

            return Ok();
        }
    }
}