using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationFinal.Models
{
    public class MaintenanceRequests
    {
        [Key]
        public int RequestId { get; set; } // Primary Key

        [Required]
        public int RoomId { get; set; } // Foreign Key from Rooms table

        [ForeignKey("RoomId")]
        public Rooms Room { get; set; } // Navigation property

        [Required]
        public int UserId { get; set; } // Foreign Key from Users table (who reported the issue)

        [ForeignKey("UserId")]
        public Users User { get; set; } // Navigation property

        [Required]
        [StringLength(255)]
        public string IssueDescription { get; set; } // Description of the maintenance issue

        [Required]
        public string Status { get; set; } = "Pending"; // Possible values: "Pending", "In Progress", "Resolved"

        public DateTime RequestDate { get; set; } = DateTime.Now; // When the request was made

        public DateTime? CompletionDate { get; set; } // Nullable, when the issue was fixed
    }
}
