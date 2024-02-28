using Mobilya_Sitesi.Models.ViewModels.Role;

namespace Mobilya_Sitesi.Models.ViewModels.User
{
    public class EditUserViewModel
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public List<ResultRoleViewModel> Roles { get; set; }
    }
}
