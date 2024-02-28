using System.Text.Json.Serialization;

namespace Mobilya_Sitesi.Models.ViewModels.Role
{
    public class ResultRoleViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsChecked { get; set; }

    }
}
