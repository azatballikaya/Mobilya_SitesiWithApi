namespace Mobilya_Sitesi.Models.ViewModels.User
{
    public class CreateUserViewModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; }
        List<string> roles { get; set; }
    }
}
