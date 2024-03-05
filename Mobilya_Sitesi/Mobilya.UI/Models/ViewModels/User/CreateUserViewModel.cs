using Mobilya_Sitesi.Models.ViewModels.Role;
using System.ComponentModel.DataAnnotations;

namespace Mobilya_Sitesi.Models.ViewModels.User
{
    public class CreateUserViewModel
    {
        [Required(ErrorMessage ="Lütfen geçerli bir kullanıcı adı giriniz.")]
        [StringLength(5,ErrorMessage ="Lütfen en az 5 karakter uzunluğunda kullanıcı adı giriniz.")]
        public string? UserName { get; set; }
        [DataType(DataType.Password)]
		[Required(ErrorMessage = "Lütfen geçerli bir parola giriniz.")]
		[StringLength(5,ErrorMessage = "Lütfen en az 5 karakter uzunluğunda parola giriniz.")]
		public string? Password { get; set; }
        
        public List<int> RoleIds { get; set; }
        public List<ResultRoleViewModel> Roles { get; set; }
        
    }
}
