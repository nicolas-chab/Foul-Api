using System.ComponentModel.DataAnnotations;

namespace Foul_Api.Models
{
    public class refereeregisterrequest1
    {
        [Required]
        public string Fullnamer { get; set; } = string.Empty;
      
        [Required,EmailAddress]
        public string emailr { get; set; } = string.Empty;
        [Required]
        public string passwordr { get; set; } = string.Empty;
        [Required,Compare("password")]
        public string confirmpasswordr { get; set; } = string.Empty;
        [Required]
        public int numerodelegajor { get; set; } 
    }
}
