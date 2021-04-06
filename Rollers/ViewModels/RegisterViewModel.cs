using System.ComponentModel.DataAnnotations;

namespace Rollers.ViewModels
{
	public class RegisterViewModel
	{
		[Required(ErrorMessage = "Please enter Login")]
		public string Login { get; set; }
		[Required(ErrorMessage = "Please enter First Name")]
		public string FirstName { get; set; }
		[Required(ErrorMessage = "Please enter Last Name")]
		public string LastName { get; set; }
		[Required(ErrorMessage = "Please enter Email")]
		public string Email { get; set; }
		[Required(ErrorMessage = "Please enter Password")]
		public string Password { get; set; }
	}
}