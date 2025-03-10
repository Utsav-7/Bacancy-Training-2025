using EF_Core_Day_3_CRUD.DBContext;
using EF_Core_Day_3_CRUD.DTOs;
using EF_Core_Day_3_CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Day_3_CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustController : ControllerBase
    {
        private readonly AppDBContext _context;

        public CustController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomers()
        {
            try
            {
                var customers = await _context.Customers
                                .Where(c => c.Active == true)
                                .Select(cust => new
                                {
                                    cust.CustId,
                                    cust.Name,
                                    cust.OrderId,
                                    cust.orders
                                }).ToListAsync();
                return Ok(customers);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("GetCustomerById/{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            try
            { 
                var exist = _context.Customers.FirstOrDefault(c => c.CustId == id && c.Active == true);
                if(exist == null)
                {
                    return NotFound($"Customer with id {id} not found");
                }
                return Ok(exist);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> AddCustomer(CustomerDTO customer)
        {
            try
            {
                var newCustomer = new Customer
                {
                    Name = customer.Name,
                    OrderId = customer.OrderId
                };
                _context.Customers.Add(newCustomer);
                await _context.SaveChangesAsync();
                return Ok("New Customer Added Successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut("UpdateCustomer/{id}")]    
        public async Task<IActionResult> UpdateCustomer(int id, CustomerDTO customer)
        {
            try
            {
                var exist = _context.Customers.FirstOrDefault(c => c.CustId == id);
                if (exist == null)
                {
                    return NotFound($"Customer with id {id} not found");
                }

                exist.Name = customer.Name;
                exist.OrderId = customer.OrderId;

                _context.Customers.Update(exist);
                await _context.SaveChangesAsync();
                return Ok($"Customer with id {id} updated successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var exist = _context.Customers.FirstOrDefault(c => c.CustId == id);
                if (exist == null)
                {
                    return NotFound($"Customer with id {id} not found");
                }
                exist.Active = false;
                await _context.SaveChangesAsync();
                return Ok($"Customer with id {id} deleted successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}