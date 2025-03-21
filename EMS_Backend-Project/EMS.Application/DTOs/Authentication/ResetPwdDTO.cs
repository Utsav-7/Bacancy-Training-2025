namespace EMS_Backend_Project.EMS.Application.DTOs.Authentication
{
    public class ResetPwdDTO
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}