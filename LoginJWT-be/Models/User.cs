using System.ComponentModel.DataAnnotations;

namespace LoginJWT_be.Models
{
    public class User
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Name cannot be longer than 50 charecters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 charecters.")]
        public string LastName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Phone number cannot be longer than 15 charecters.")]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Birthdate cannot be longer than 10 charecters.")]
        public string BirthDate { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Username cannot be longer than 20 charecters.")]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(50, ErrorMessage = "Email cannot be longer than 50 charecters.")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Password cannot be longer than 100 charecters.")]
        public string Password { get; set; }
    }
}
