using System.ComponentModel.DataAnnotations;

namespace PustokTemplate.ViewModels
{
	public class ForgotPasswordViewModel
	{
		[Required]
		[DataType(DataType.EmailAddress)]
		[MaxLength(50)]
		public string Email { get; set; }
	}
}
