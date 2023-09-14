using System.ComponentModel.DataAnnotations;

namespace eMovies.Data.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Email address")]
        [Required(ErrorMessage = "Email address is required!")]
        public string EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        //qe mu bo hidden qka  t shkrujm nfield osht datatype.password
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
