using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationFinal.Models
{
    public class Housekeeping
    {
        [Key]
        public int HousekeepingId { get; set; } // Primary Key

        [Required]
        public int RoomId { get; set; } // Foreign Key from Rooms table

        [ForeignKey("RoomId")]
        public Rooms? Room { get; set; } // Navigation property

        [Required]
        public int UserId { get; set; } // Foreign Key from Users table

        [ForeignKey("UserId")]
        public Users? User { get; set; } // Navigation property

        [Required]
        [MaxLength(255)]
        public string RequestType { get; set; } = string.Empty;// E.g., "Cleaning", "Laundry", "Maintenance"

        [MaxLength(500)]
        public string? Notes { get; set; } // Optional additional details

        [Required]
        public DateTime RequestedAt { get; set; } = DateTime.Now; // Auto-generated timestamp

        [Required]
        public string Status { get; set; } = "Pending"; // Default status: Pending, Completed, In Progress

        public DateTime? CompletedAt { get; set; } // Time when housekeeping was completed
    }
}
