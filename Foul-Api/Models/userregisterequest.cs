using System.ComponentModel.DataAnnotations;

namespace Foul_Api.Models
{
    public class refereeregisterrequest
    {
        [Required]
        public string FirstAndLastNamee { get; set; } = string.Empty;
      
        [Required,EmailAddress]
        public string email { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
        [Required,Compare("password")]
        public string confirmpassword { get; set; } = string.Empty;
        [Required]
        public string numerodelegajo { get; set; } = string.Empty;
    }
}
