using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EFCore_Day_4_Loading_Types.DBContext;
using EFCore_Day_4_Loading_Types.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EFCore_Day_4_Loading_Types.Controllers
{
    public class CombineController : Controller
    {
        private readonly AppDBContext _dbContext;
        public CombineController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //Implement a solution where Orders are fetched with eager loading, but the OrderProducts are loaded lazily only when accessed.
        [HttpGet("Combination/GetOrdersWithLazyOrderProducts")]
        public IActionResult GetOrdersWithLazyOrderProducts()
        {
            var ordersData = _dbContext.orders.Include(o => o.customer) // Eagerly load Customers
                                          .ToList();
            var result = ordersData.Select(s => new
                                    {
                                        s.OrderId,
                                        s.OrderDate,
                                        OrderProduct = s.orderProduct.Select(op => new
                                        {
                                            op.products.Name,
                                            op.products.Price,
                                            op.products.Stock
                                        })
                                    });
                
            return Ok(result);
        }

        //Develop a query that efficiently fetches Orders with eager loading but performs explicit loading for OrderProducts where the quantity is greater than 5.
        [HttpGet("Combination/GetOrdersWithHighQuantityOrderProducts")]
        public IActionResult GetOrdersWithHighQuantityOrderProducts()
        {
            var orders = _dbContext.orders
                                         .Include(o => o.customer); // Eagerly load Customers
                                         //.ToList();

            Console.WriteLine("Orders fetched. OrderProducts will be explicitly loaded where Quantity > 5.");

            foreach (var order in orders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Date: {order.OrderDate}, Customer: {order.customer.Name}");

                // Explicitly load OrderProducts only where Quantity > 5
                 _dbContext.Entry(order)
                                .Collection(o => o.orderProduct)
                                .Query()
                                .Where(op => op.Quantity > 5)
                                .Load();

                Console.WriteLine($"Loaded {order.orderProduct.Count} OrderProducts (Quantity > 5).");
            }
            return Ok();
        }

        //Write a method that retrieves a Customer’s Orders eagerly and explicitly loads OrderProducts only if the Customer is marked as “VIP”.
        [HttpGet("Combination/RetrieveIsVIPGetCustomer")]
        public IActionResult RetrieveIsVIPGetCustomer()
        {
            try
            {
                var VIPCustomer = _dbContext.customers.Where(c => c.IsVIP == true).Include(o => o.orders);

                foreach(var cust in VIPCustomer)
                {  
                    if(cust.IsVIP)
                    {
                        foreach(var order in cust.orders)
                        {
                            _dbContext.Entry(order).Collection(c => c.orderProduct).Load();
                        }
                    }
                }

                return Ok(VIPCustomer);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}