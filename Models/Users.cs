using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationFinal.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public Roles? Role { get; set; }

     
        // Navigation Property: One user can have many CheckInOut records
        public List<CheckInOut> CheckInOuts { get; set; } = new List<CheckInOut>();

        public ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();


    }
}
