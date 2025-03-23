using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationFinal.Models
{
    public class Rooms
    {
        [Key]
        public int RoomId { get; set; } // Primary Key

        [Required]
        [StringLength(50)]
        public string RoomNumber { get; set; } = string.Empty; // Unique room number

        [Required]
        [ForeignKey("RoomCategories")]
        public int CategoryId { get; set; } // Foreign Key to RoomCategories

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerNight { get; set; } // Room rate

        [Required]
        public bool IsAvailable { get; set; } // Room availability status

        public string Description { get; set; } = string.Empty; // Optional room description

        // Navigation Properties
        public RoomCategories? RoomCategory { get; set; } // Links to RoomCategories

        public ICollection<Bookings> Bookings { get; set; } = new List<Bookings>();

    }
}
