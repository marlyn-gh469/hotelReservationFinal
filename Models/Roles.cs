using System.ComponentModel.DataAnnotations;

namespace HotelReservationFinal.Models
{
    public class Roles
    {
        [Key]
        public int RoleId { get; set; } // Primary Key

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; } = string.Empty;// Role Name (e.g., "Admin", "Guest")
    }
}
