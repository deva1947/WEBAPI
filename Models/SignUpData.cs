using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class SignUpData
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }
    }
}



//  [Required]
//         public int UserID { get; set; }