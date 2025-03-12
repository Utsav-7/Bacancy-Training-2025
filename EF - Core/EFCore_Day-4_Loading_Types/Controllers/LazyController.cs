using System.ComponentModel;
using System;
using EFCore_Day_4_Loading_Types.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using EFCore_Day_4_Loading_Types.Models;

namespace EFCore_Day_4_Loading_Types.Controllers
{
    public class LazyController : Controller
    {
        private readonly AppDBContext _dbContext;
        public LazyController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Write a LINQ query that retrieves Customers with their Orders, ensuring lazy loading is used.Print the result and add logs to display the SQL queries being executed to track performance.
        [HttpGet("Lazy/GetCustomers")]
        public IActionResult GetCustomersLazyLoading()
        {
            try
            {
                var customers = _dbContext.customers.ToList();
                var result = customers.Select(customer => new
                {
                    customer.Name,
                    customer.Email,
                    Orders = customer.orders.Select(order => new
                    {
                        order.OrderId,
                        order.OrderDate
                    }).ToList()
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error occurred while fetching data.");
            }
        }

        // Implement a method where lazy loading is combined with conditional logic — for instance, load Orders only if their total amount exceeds $500.
        [HttpGet("Lazy/highValueOrders")]
        public async Task<IActionResult> GetHighValueOrders()
        {
            try
            {
                var orders = await _dbContext.orders.ToListAsync();

                var result = _dbContext.orders.Select(o => new
                {
                    o.OrderDate,
                    OrderedProduct = o.orderProduct
                                      .Where(op => op.Quantity * op.products.Price > 500)
                                      .Select(s => new
                                      {
                                          Name = s.products.Name,
                                          Price = s.products.Price,
                                          Stock = s.Quantity      
                                      }).ToList()
                    
                })
                .Where(o => o.OrderedProduct.Any()) // Keep only orders with at least one high-value product
                .ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error occurred while fetching data.");
            }
        }
    }
}