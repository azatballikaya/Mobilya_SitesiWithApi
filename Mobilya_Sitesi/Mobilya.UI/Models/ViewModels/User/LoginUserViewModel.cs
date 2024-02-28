namespace Mobilya_Sitesi.Models.ViewModels.User
{
    public class LoginUserViewModel
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public List<string>? RoleNames { get; set; }
    }
}
