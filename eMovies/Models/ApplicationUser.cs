using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace eMovies.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Display(Name = "Full name")]
        public string FullName { get; set; }
        public List<Order> Orders { get; set; }
    }
}
