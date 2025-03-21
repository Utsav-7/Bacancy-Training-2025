namespace EMS_Backend_Project.EMS.Application.DTOs.UserDTOs
{
    public class EmplyeeUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Password { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string TeckStack { get; set; }
        public DateOnly JoinDate { get; set; }
        public DateOnly RelievingDate { get; set; }
    }
}