using System.ComponentModel;
using System.Net.NetworkInformation;
using EFCore_Day_4_Loading_Types.DBContext;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EFCore_Day_4_Loading_Types.Controllers
{
    public class EagarController : Controller
    {
        private readonly AppDBContext _dbContext;

        public EagarController(AppDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Write a LINQ query that retrieves all Customers with their related Orders and OrderProducts in a single query using eager loading.
        [HttpGet("Eagar/GetCustomer")]
        public IActionResult EagerGetCustomer()
        {
            try
            {
                //// Raw SQL Syntax
                // FormattableString sql = $"SELECT * FROM customers";
                // var query = _dbContext.customers.FromSql(sql).Include(o => o.orders);

                // Eager Loading and Immediate execution
                var records = _dbContext.customers.Include(o => o.orders)
                                                .ThenInclude(op => op.orderProduct)
                                                .Select(c => new
                                                {
                                                    c.Name,
                                                    c.Email,
                                                    Orders = c.orders.Select(o => new
                                                    {
                                                        o.OrderDate,
                                                        OrderProducts = o.orderProduct.Select(op => new
                                                        {
                                                            ProductId = op.products.Id,
                                                            ProductName = op.products.Name,
                                                            ProductPrice = op.products.Price,
                                                            Quantity = op.Quantity
                                                        }).ToList()
                                                    }).ToList()
                                                })
                                                .ToList();

                return Ok(records);
            }
            catch (Exception ex)
            {
                return BadRequest("Error during processing your request");
            }
        }


        // Modify the above query to include only Orders placed in the last 30 days and only Products with stock greater than 20.
        [HttpGet("Eager/FilteredData")]
        public IActionResult FilteredData()
        {
            try
            {
                var filteredData = _dbContext.orders
                                                .Where(o => o.OrderDate >= DateTime.UtcNow.AddDays(-30))
                                                .Include(o => o.orderProduct)
                                                .ThenInclude(op => op.products)
                                                .Select(o => new
                                                {
                                                    o.customer,
                                                    o.OrderDate,
                                                    OrderProduct = o.orderProduct.Where(op => op.products.Stock > 20)
                                                    .Select(p => new
                                                    {
                                                        p.products.Name,
                                                        p.products.Price,
                                                        p.products.Stock
                                                    }).ToList()
                                                }).ToList();
                return Ok(filteredData);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return BadRequest("An error occurred while processing your request.");
            }

        }

        // Write a LINQ query that fetches Products along with the total number of Orders they are associated with using eager loading.Print the result.
         [HttpGet("Eager/TotalOrders")]
        public IActionResult TotalOrders()
        {
            try
            {
                var productsWithOrderCount = _dbContext.products
                                                .Include(p => p.orderProduct)
                                                .Select(p => new
                                                {
                                                    p.Name,
                                                    Count = p.orderProduct.Count
                                                })
                                                .ToList();

                return Ok(productsWithOrderCount);
            }
            catch(Exception ex)
            {
                return BadRequest("Error Occured.");
            }
        }

        // Using eager loading, write a query that retrieves Orders placed in the last month, including the related Customer but excluding OrderProducts.
        [HttpGet("Eager/CustRelatedOrder")]
        public IActionResult CustRelatedOrder()
        {
            try
            {
                var lastMonthOrders = _dbContext.orders
                                                .Where(o => o.OrderDate >= DateTime.UtcNow.AddMonths(-1))
                                                .Include(o => o.customer)
                                                .Select(s => new
                                                {
                                                    s.CustomerId,
                                                    s.customer,
                                                    s.OrderDate
                                                }).ToList();
                                                
                return Ok(lastMonthOrders);

            }
            catch (Exception ex)
            {
                return BadRequest("Error Occured.");
            }
        }
    }
}