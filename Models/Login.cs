using System.ComponentModel.DataAnnotations;
namespace Orphanage.Models
{
    public class Login
    {
        [Required]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        public string ReturnUrl { get; set; } = "/";
    }
}