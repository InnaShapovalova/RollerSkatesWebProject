using System.ComponentModel.DataAnnotations;

namespace Rollers.ViewModels
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Please enter Login")]
		public string Login { get; set; }

		[Required(ErrorMessage = "Please enter Password")]
		public string Password { get; set; }
	}
}