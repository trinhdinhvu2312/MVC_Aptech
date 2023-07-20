using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MVC_Aptech.Models
{
    [Table("tblUser")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        [StringLength(100, MinimumLength = 3, ErrorMessage = "Full Name must be between 3 and 100 characters")]
        [Required]
        public string? FullName { get; set; }

        [Required]
        [MaxLength(255, ErrorMessage = "Password must be at least 4 characters")]
        [MinLength(4)]
        public string? Password { get; set; }

    }
}
