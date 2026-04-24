using System.ComponentModel.DataAnnotations;

namespace Vehicle_System.Models
{
    public class User
    {
    
            [Key]
            public int UserId { get; set; }

            [Required]
            public string ? Name { get; set; }

            [Required]
            [StringLength(11, MinimumLength = 11)]
            public string ? Phone { get; set; }

            public ICollection<Vehicle> Vehicles { get; set; }
        }
    }

