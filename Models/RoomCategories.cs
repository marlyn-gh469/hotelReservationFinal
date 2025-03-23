using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace HotelReservationFinal.Models
{
    public class RoomCategories
    {
        [Key]
        public int CategoryId { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; } = string.Empty;// e.g., "Standard", "Deluxe", "Suite"

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;// Brief description of the category

        public List<Rooms> Rooms { get; set; } = new List<Rooms>();
    }
}
