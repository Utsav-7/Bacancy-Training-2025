using EMS_Backend_Project.EMS.Application.DTOs.LeavesDTOs;
using EMS_Backend_Project.EMS.Application.Interfaces.LeaveManagement;
using EMS_Backend_Project.EMS.Domain.Entities;
using EMS_Backend_Project.EMS.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace EMS_Backend_Project.EMS.Infrastructure.Repositories
{
    public class LeaveRepository : Repository<Leave>, ILeaveRepository
    {
        public LeaveRepository(ApplicationDBContext context) : base(context){}

        public async Task AddLeave(LeaveDTO leave)
        {
            var newLeave = new Leave
            {
                EmployeeId = leave.EmployeeId,
                StartDate = leave.StartDate,
                EndDate = leave.EndDate,
                TotalDays = (leave.EndDate.ToDateTime(TimeOnly.MinValue) - leave.StartDate.ToDateTime(TimeOnly.MinValue)).Days + 1,
                LeaveType = leave.LeaveType,
                Reason = leave.LeaveType,
                Status = leave.Status,
                AppliedAt = DateTime.UtcNow,
                UpdatedAt = null
            };
            _context.Leaves.Add(newLeave);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteLeave(int id)
        {
            var existingLeave = await _context.Leaves.FindAsync(id);

            if (existingLeave == null)
                throw new Exception("No Leave records found.");

            _context.Leaves.Remove(existingLeave);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<GetLeaveDTO>> GetAllLeaves()
        {
            var leaveRecords = await _context.Leaves
                                            .Include(s => s.Employee)
                                                .ThenInclude(e => e.User)
                                            .Include(s => s.Employee.Department)
                                            .Select(s => new GetLeaveDTO
                                            {
                                                LeaveId = s.LeaveId,
                                                EmployeeName = s.Employee.User.FirstName + " " + s.Employee.User.LastName,
                                                DepartmentName = s.Employee.Department.DepartmentName,
                                                StartDate = s.StartDate,
                                                EndDate = s.EndDate,
                                                TotalDays = s.TotalDays,
                                                LeaveType = s.LeaveType,
                                                Reason = s.Reason,
                                                Status = s.Status,
                                                AppliedAt = s.AppliedAt
                                            }).ToListAsync();

            return leaveRecords;
        }

        public async Task<GetLeaveDTO> GetLeaveByID(int id)
        {
            var leaveRecord = await _context.Leaves.Include(s => s.Employee)
                                                                .ThenInclude(u => u.User)
                                                                .ThenInclude(d => d.Employee.Department)
                                                                .Where(c => c.LeaveId == id)
                                                                .Select(s => new GetLeaveDTO
                                                                {
                                                                    LeaveId = s.LeaveId,
                                                                    EmployeeName = s.Employee.User.FirstName + " " + s.Employee.User.LastName,
                                                                    DepartmentName = s.Employee.Department.DepartmentName,
                                                                    StartDate = s.StartDate,
                                                                    EndDate = s.EndDate,
                                                                    TotalDays = s.TotalDays,
                                                                    LeaveType = s.LeaveType,
                                                                    Reason = s.Reason,
                                                                    Status = s.Status,
                                                                    AppliedAt = s.AppliedAt
                                                                }).FirstOrDefaultAsync();

            if (leaveRecord == null)
                throw new Exception("No Leave records found.");

            return leaveRecord;
        }

        public async Task UpdateLeave(int id, LeaveDTO leave)
        {
            var existingRecord = await _context.Leaves.FindAsync(id);

            if (existingRecord == null)
                throw new KeyNotFoundException("No Leave Record Found.");

            existingRecord.EmployeeId = leave.EmployeeId;
            existingRecord.StartDate = leave.StartDate;
            existingRecord.EndDate = leave.EndDate;
            existingRecord.LeaveType = leave.LeaveType;
            existingRecord.Reason = leave.Reason;
            existingRecord.Status = leave.Status;
            existingRecord.TotalDays = (leave.EndDate.ToDateTime(TimeOnly.MinValue) - leave.StartDate.ToDateTime(TimeOnly.MinValue)).Days + 1;
            existingRecord.UpdatedAt = DateTime.UtcNow;

            _context.Leaves.Update(existingRecord);
            await _context.SaveChangesAsync();
        }
    }
}