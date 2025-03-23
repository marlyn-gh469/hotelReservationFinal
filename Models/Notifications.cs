using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationFinal.Models
{
    public class Notifications
    {
        [Key]
        public int NotificationId { get; set; } // Primary Key

        [Required]
        public int UserId { get; set; } // Foreign Key (who receives the notification)

        [ForeignKey("UserId")]
        public Users User { get; set; } // Navigation property

        [Required]
        [StringLength(255)]
        public string Message { get; set; } // Notification message

        public bool IsRead { get; set; } = false; // Whether the user has read the notification

        public DateTime CreatedAt { get; set; } = DateTime.Now; // Timestamp for when the notification was created
    }
}
