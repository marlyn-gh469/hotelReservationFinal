using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationFinal.Models
{
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; } // Primary Key

        [Required]
        public int BookingId { get; set; } // Foreign Key (Links to Booking)

        [ForeignKey("BookingId")]
        public Bookings? Booking { get; set; } // Navigation Property

        [Required]
        public int UserId { get; set; } // Foreign Key (User making the payment)

        [ForeignKey("UserId")]
        public Users? User { get; set; } // Navigation Property

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; } // Payment Amount

        [Required]
        [StringLength(50)]
        public string PaymentMethod { get; set; } = string.Empty; // Payment Method (Cash, Credit Card, etc.)

        public DateTime PaymentDate { get; set; } = DateTime.Now; // When the payment was made

        [Required]
        public PaymentStatus Status { get; set; } = PaymentStatus.Pending; // Enum for better tracking

        [StringLength(100)]
        public string? TransactionReference { get; set; } // Optional unique transaction ID
    }

    public enum PaymentStatus
    {
        Pending,
        Completed,
        Failed
    }
}
