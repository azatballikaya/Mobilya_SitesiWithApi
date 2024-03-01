using System.ComponentModel.DataAnnotations;

namespace Mobilya_Sitesi.Models.ViewModels.User
{
    public class LoginUserViewModel
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        
        public List<string>? RoleNames { get; set; }
    }
}
