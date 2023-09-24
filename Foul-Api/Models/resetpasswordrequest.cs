using System.ComponentModel.DataAnnotations;

namespace Foul_Api.Models
{
    public class resetpasswordrequest
    {
        [Required]
        public string token { get; set; } = string.Empty;
        [Required]
        public string password { get; set; } = string.Empty;
        [Required, Compare("password")]
        public string confirmpassword { get; set; } = string.Empty;
    }
}
