using AutoMapper;
using EMS_Backend_Project.EMS.Application.DTOs.UserDTOs;
using EMS_Backend_Project.EMS.Application.Interfaces;
using EMS_Backend_Project.EMS.Application.Interfaces.UserManagement;
using EMS_Backend_Project.EMS.Common.CustomExceptions;
using EMS_Backend_Project.EMS.Domain.Entities;
using EMS_Backend_Project.EMS.Infrastructure.Database;
using EMS_Backend_Project.EMS.Infrastructure.Mapping;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace EMS_Backend_Project.EMS.Infrastructure.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDBContext context, IEmailService emailService, IMapper mapper) : base(context)
        {
            _emailService = emailService;
            _mapper = mapper;
        }

        public async Task<ICollection<UserDTO>> GetAllUser()
        {
            var usersList = await _context.Users.Where(c => c.IsDeleted == false).Select(s => new UserDTO
            {
                UserId = s.UserId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                PhoneNo = s.PhoneNo,
                RoleName = s.Role.RoleName,
                Active = s.Active,
                CreatedAt = s.CreatedAt
            }).ToListAsync();

            if (usersList == null)
                throw new DataNotFoundException<string>("No User found.");

            return usersList;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _context.Users.Where(c => c.UserId == id && c.IsDeleted == false).Select(s => new UserDTO
            {
                UserId = s.UserId,
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                PhoneNo = s.PhoneNo,
                RoleName = s.Role.RoleName,
                Active = s.Active,
                CreatedAt = s.CreatedAt
            }).FirstOrDefaultAsync();

            if (user == null)
                throw new DataNotFoundException<int>(id);

            return user;
        }

        public async Task AddAdmin(AdminUserDTO adminUserDTO)
        {
            var existingUser = _context.Users.FirstOrDefault(s => s.Email == adminUserDTO.Email);

            if(existingUser != null)
            {
                if (existingUser.IsDeleted == true)
                {
                    existingUser.IsDeleted = false;
                    _context.Users.Update(existingUser);
                    await _context.SaveChangesAsync();
                    await _emailService.SendUserRegistrationEmailAsync(adminUserDTO.Email, adminUserDTO.Password);
                    return;
                }
                else
                {
                    throw new AlreadyExistsException<string>($"User is already exists with {adminUserDTO.Email}");
                }
            }

            // Hash the password
            var passwordHasher = new PasswordHasher<AdminUserDTO>();
            var hashedPassword = passwordHasher.HashPassword(adminUserDTO, adminUserDTO.Password);

            var newAdmin = new User
            {
                FirstName = adminUserDTO.FirstName,
                LastName = adminUserDTO.LastName,
                Email = adminUserDTO.Email,
                PhoneNo = adminUserDTO.PhoneNo,
                Password = hashedPassword,
                RoleId = 1,
                Active = true,
                IsDeleted = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(newAdmin);
            await _context.SaveChangesAsync();

            await _emailService.SendUserRegistrationEmailAsync(adminUserDTO.Email, adminUserDTO.Password);
        }

        public async Task AddEmployee(EmplyeeUserDTO emplyeeUserDTO)
        {
            var roleExists = await _context.Departments.AnyAsync(r => r.DepartmentId == emplyeeUserDTO.DepartmentId);
            if (!roleExists)
            {
                throw new Exception("Invalid RoleId. Role does not exist.");
            }

            var existingEmployee = await _context.Users.FirstOrDefaultAsync(c => c.Email == emplyeeUserDTO.Email);

            if (existingEmployee != null)
            {
                if (existingEmployee.IsDeleted == true)
                {
                    existingEmployee.IsDeleted = false;
                    _context.Users.Update(existingEmployee);
                    await _context.SaveChangesAsync();
                    await _emailService.SendUserRegistrationEmailAsync(emplyeeUserDTO.Email, emplyeeUserDTO.Password);
                    return;
                }
                else
                {
                    throw new AlreadyExistsException<string>(emplyeeUserDTO.Email);
                }
            }

            // Hash the password
            var passwordHasher = new PasswordHasher<EmplyeeUserDTO>();
            var hashedPassword = passwordHasher.HashPassword(emplyeeUserDTO, emplyeeUserDTO.Password);

            // Map DTO to User entity
            var user = _mapper.Map<User>(emplyeeUserDTO);
            user.Password = hashedPassword;  
            user.RoleId = 2;
            user.CreatedAt = DateTime.UtcNow;
            user.UpdatedAt = DateTime.UtcNow;

            // Map DTO to Employee entity
            var employee = _mapper.Map<Employee>(emplyeeUserDTO);
            employee.User = user;  // Establish relationship with User
            employee.DepartmentId = emplyeeUserDTO.DepartmentId;

            // Save to database
            await _context.Users.AddAsync(user);
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            await _emailService.SendUserRegistrationEmailAsync(emplyeeUserDTO.Email, emplyeeUserDTO.Password);
        }

        public async Task UpdateAdminById(int id, AdminUserDTO adminUserDTO)
        {
            var checkEmail = await _context.Users.FirstOrDefaultAsync(s => s.Email == adminUserDTO.Email && s.UserId != id);

            if (checkEmail != null)
                throw new AlreadyExistsException<string>($"User is Already exist with {adminUserDTO.Email}");

            var existingAdmin = await _context.Users.FindAsync(id);

            if (existingAdmin == null)
                throw new DataNotFoundException<int>(id);

            existingAdmin.FirstName = adminUserDTO.FirstName ?? existingAdmin.FirstName;
            existingAdmin.LastName = adminUserDTO.LastName ?? existingAdmin.LastName;
            existingAdmin.Email = adminUserDTO.Email ?? existingAdmin.Email;
            existingAdmin.PhoneNo = adminUserDTO.PhoneNo ?? existingAdmin.PhoneNo;
            existingAdmin.Active = adminUserDTO.Active;
            existingAdmin.UpdatedAt = DateTime.UtcNow;

            _context.Users.Update(existingAdmin);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateEmployeeById(int id, EmplyeeUserDTO emplyeeUserDTO)
        {
            var checkEmail = await _context.Users.FirstOrDefaultAsync(s => s.Email == emplyeeUserDTO.Email && s.UserId != id);
            
            if (checkEmail != null)
                throw new AlreadyExistsException<string>(checkEmail.Email);

            // Fetch existing User with Employee details
            var existingUser = await _context.Users
                .Include(u => u.Employee)
                .FirstOrDefaultAsync(u => u.UserId == id && u.RoleId == 2);

            if (existingUser == null)
                throw new DataNotFoundException<int>(id);

            // Update User entity
            existingUser.FirstName = emplyeeUserDTO.FirstName ?? existingUser.FirstName;
            existingUser.LastName = emplyeeUserDTO.LastName ?? existingUser.LastName;
            existingUser.Email = emplyeeUserDTO.Email ?? existingUser.Email;
            existingUser.PhoneNo = emplyeeUserDTO.PhoneNo ?? existingUser.PhoneNo;
            existingUser.Employee.Address = emplyeeUserDTO.Address ?? existingUser.Employee.Address;
            existingUser.Active = emplyeeUserDTO.Active;
            existingUser.UpdatedAt = DateTime.UtcNow;

            if (emplyeeUserDTO.DateOfBirth != default)
                existingUser.Employee.DateOfBirth = emplyeeUserDTO.DateOfBirth;

            // Hash the password only if a new one is provided
            if (!string.IsNullOrEmpty(emplyeeUserDTO.Password))
            {
                var passwordHasher = new PasswordHasher<User>();
                existingUser.Password = passwordHasher.HashPassword(existingUser, emplyeeUserDTO.Password);
            }

            // Check if Employee exists and update it
            if (existingUser.Employee != null)
            {
                existingUser.Employee.DepartmentId = emplyeeUserDTO.DepartmentId;
                existingUser.Employee.TeckStack = emplyeeUserDTO.TeckStack ?? existingUser.Employee.TeckStack;

                if (emplyeeUserDTO.JoinDate != default)
                    existingUser.Employee.JoinDate = emplyeeUserDTO.JoinDate;

                if (emplyeeUserDTO.RelievingDate != default)
                    existingUser.Employee.RelievingDate = emplyeeUserDTO.RelievingDate;

                _context.Entry(existingUser.Employee).State = EntityState.Modified;
            }

            // Mark User entity as modified
            _context.Entry(existingUser).State = EntityState.Modified;

            // Save changes
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserById(int id)
        {
            var existingUser = await _context.Users.FindAsync(id);

            if (existingUser == null)
                throw new DataNotFoundException<int>(id);

            existingUser.IsDeleted = true;
            existingUser.Active = false;

            await _context.SaveChangesAsync();
        }
    }
}