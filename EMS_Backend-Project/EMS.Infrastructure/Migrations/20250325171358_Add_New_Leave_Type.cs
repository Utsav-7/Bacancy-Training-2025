using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EMS_Backend_Project.Migrations
{
    /// <inheritdoc />
    public partial class Add_New_Leave_Type : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Leave_LeaveType",
                table: "Leaves");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Leave_LeaveType",
                table: "Leaves",
                sql: "LeaveType IN ('Sick Leave', 'Casual Leave', 'Vacation', 'Paid Leave', 'Maternity Leave', 'Paternity Leave','Unpaid Leave', 'Other')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Leave_LeaveType",
                table: "Leaves");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Leave_LeaveType",
                table: "Leaves",
                sql: "LeaveType IN ('SickLeave', 'CasualLeave', 'Vacation', 'UnpaidLeave', 'Other')");
        }
    }
}
