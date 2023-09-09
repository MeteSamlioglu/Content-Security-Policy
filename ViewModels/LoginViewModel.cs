using System.ComponentModel.DataAnnotations;

namespace RunGroopWebApp.ViewModels
{

    public class LoginViewModel
    {
        [Display(Name = "Email Address")] /* This is called validation annotations */
        [Required(ErrorMessage = "Email address is required")]
        public string EmailAddress{get; set;}
        [Required]
        [DataType(DataType.Password)]
        public string Password{get; set;}

    }


}