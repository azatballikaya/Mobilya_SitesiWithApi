using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Mobilya_Sitesi.Models.ViewModels.User
{
	public class RegisterUserViewModel
	{
		[Required(ErrorMessage = "Lütfen geçerli bir kullanıcı adı giriniz.")]
		[StringLength(50,MinimumLength =5, ErrorMessage = "Lütfen en az 5 karakter uzunluğunda kullanıcı adı giriniz.")]
		public string? UserName { get; set; }
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Lütfen geçerli bir parola giriniz.")]
		[StringLength(50,MinimumLength =5, ErrorMessage = "Lütfen en az 5 karakter uzunluğunda parola giriniz.")]
		public string? Password { get; set; }
		[DataType(DataType.Password)]
		[Required(ErrorMessage = "Lütfen parolayı tekrar giriniz.")]
		[Compare("Password", ErrorMessage = "Parola eşleşmiyor.")]
		[JsonIgnore]
		public string? PasswordCheck { get; set; }

        public List<int> RoleIds { get; set; }=new List<int>();
	}
}
