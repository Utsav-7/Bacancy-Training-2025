# Entity Framework : Day - 5 
## Problem Statement:
- Create a fully functional .NET Core Web API project that demonstrates mastery over Entity Framework Core (EF Core) concepts including model creation, relationships, migrations, data seeding, CRUD operations, and data loading techniques.
- **Assignment:** https://docs.google.com/document/d/1ixE6Jgn-uYzyapkCl0Ys6dm6FN0lEINkfRsqPSde4BM/edit?tab=t.0#heading=h.uw2xpk5yae2

## 🚀 Features Implemented: 
- CRUD Operations for Employee, Department, and Project
  - Many-to-Many Relationship (Employee ↔ EmployeeProject ↔ Project)
  - One-to-Many Relationship (Department → Employees)
  - Transaction Handling in Employee Controller
  - Eager Loading & Lazy Loading for data fetching

## 📂 Database Schema & Relationships
### Tables & Keys
- Employee (EmployeeId - Primary Key)
- Department (DepartmentId - Primary Key)
- Project (ProjectId - Primary Key)
- EmployeeProject (Composite Key: EmployeeId + ProjectId)

### Entity Relationships
- One-to-Many: Department → Employees
- Many-to-Many: Employee ↔ EmployeeProject ↔ Project

## 📌 API Endpoints

### **Department Controller**
| Method  | Endpoint               | Description                         |
|---------|------------------------|-------------------------------------|
| POST    | `/api/departments`      | Create a new department            |
| GET     | `/api/departments/{id}` | Get department details with employees |
| PUT     | `/api/departments/{id}` | Update department information      |
| DELETE  | `/api/departments/{id}` | Delete a department                |

### **Employee Controller**
| Method  | Endpoint                            | Description                                |
|---------|-------------------------------------|--------------------------------------------|
| POST    | `/api/employees`                   | Create a new employee                     |
| GET     | `/api/employees/{id}`              | Get employee details by ID                |
| PUT     | `/api/employees/{id}`              | Update employee information               |
| DELETE  | `/api/employees/{id}`              | Delete an employee                        |

### **Project Controller**
| Method  | Endpoint               | Description                        |
|---------|------------------------|------------------------------------|
| POST    | `/api/projects`        | Create a new project              |
| GET     | `/api/projects/{id}`   | Get project details with employees |
| PUT     | `/api/projects/{id}`   | Update project details            |
| DELETE  | `/api/projects/{id}`   | Delete a project                  |

## 🔄 Implemented Sample Transaction Code
- The following code demonstrates a transaction where an employee and a department are added atomically. If any operation fails, changes are rolled back.
```
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
```
### Screenshot:
![Screenshot 2025-03-13 185812](https://github.com/user-attachments/assets/155a43c4-693d-4c6c-95f4-aa0b4230e206)

