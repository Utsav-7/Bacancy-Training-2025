using EFCore_Day_5_Full_CRUD.DBContext;
using EFCore_Day_5_Full_CRUD.DTOs;
using EFCore_Day_5_Full_CRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Day_5_Full_CRUD.Controller
{
    [ApiController]
    [Controller]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDBContext _dbContext;
        public EmployeeController(AppDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(EmployeeDTO employee)
        {
            using (var transaction = await _dbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    Console.WriteLine("Transaction is BEGIN...................");
                    var newEmployee = new Employee
                    {
                        Name = employee.Name,
                        Email = employee.Email,
                        DepartmentId = employee.DepartmentId
                    };

                    _dbContext.Employees.Add(newEmployee);
                    await _dbContext.SaveChangesAsync();

                    await transaction.CommitAsync();
                    Console.WriteLine("Transaction is COMMIT..........................");
                    return Ok("New Employee Added successfully.");
                }
                catch(Exception ex)
                {
                    await transaction.RollbackAsync();
                    Console.WriteLine("Transaction is ROLLBACK..........................");
                    return BadRequest($"Exception: {ex}");
                }
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(int id)
        {
            try
            {
                var fetchData = _dbContext.Employees.Include(ep => ep.EmployeeProjects)
                                                    .ThenInclude(p => p.Project)
                                                    .Where(e => e.EmployeeId == id)
                                                    .Select(s => new
                                                    {
                                                        Name = s.Name,
                                                        Email = s.Email,
                                                        ProjectDetails = s.EmployeeProjects.Select(ns => new
                                                        {
                                                            ProjectName = ns.Project.ProjectName,
                                                            Role = ns.Role,
                                                            StartDate = ns.Project.StartDate
                                                        })
                                                    });

                return Ok(fetchData);
            }
            catch (Exception ex)
            {
                return BadRequest($"Exception: {ex}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployeeById(int id, [FromBody] EmployeeDTO employee)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            Console.WriteLine("Transaction is BEGIN...................");
            try
            {
                var updateData = _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);

                updateData.Name = employee.Name;
                updateData.Email = employee.Email;
                updateData.EmployeeId = employee.DepartmentId;

                transaction.CreateSavepointAsync("Before Data Add....");

                _dbContext.Employees.Update(updateData);
                
                transaction.ReleaseSavepointAsync("After Data Add....");

                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();
                Console.WriteLine("Transaction is COMMIT..........................");
                return Ok($"Employee with Id: {id} is updated...");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine("Transaction is ROLLBACK..........................");
                return BadRequest($"Exception: {ex}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult>  DeleteEmployeeById(int id)
        {
            using var transaction = await _dbContext.Database.BeginTransactionAsync();
            Console.WriteLine("Transaction is BEGIN...................");
            try
            {
                var updateData = _dbContext.Employees.FirstOrDefault(e => e.EmployeeId == id);

                _dbContext.Employees.Remove(updateData);
                await _dbContext.SaveChangesAsync();

                await transaction.CommitAsync();
                Console.WriteLine("Transaction is COMMIT..........................");
                return Ok($"Employee with Id: {id} is Deleted...");
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                Console.WriteLine("Transaction is ROLLBACK..........................");
                return BadRequest($"Exception: {ex}");
            }
        }
    }
}