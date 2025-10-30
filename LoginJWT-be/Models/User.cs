using System.ComponentModel.DataAnnotations;

namespace LoginJWT_be.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(55)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(55)]
        public string Password { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Role { get; set; }
    }
}
