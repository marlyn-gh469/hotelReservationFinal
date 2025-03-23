using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationFinal.Models
{
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoomId { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")] // Ensure correct precision for TotalAmount
        public decimal TotalAmount { get; set; }

        [ForeignKey("UserId")]
        public Users? User { get; set; }

        [ForeignKey("RoomId")]
        public Rooms? Room { get; set; }

        // Navigation property for invoices
       
    }
}
