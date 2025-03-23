using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationFinal.Models
{
    public class CheckInOut
    {
        [Key]
        public int CheckInOutId { get; set; }
        public int UserId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime? CheckOutDate { get; set; }

        [ForeignKey("UserId")]
        public Users? User { get; set; }
    }
}
