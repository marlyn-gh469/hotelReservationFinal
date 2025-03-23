using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelReservationFinal.Models
{
    public class Reports
    {
        [Key]
        public int ReportId { get; set; } // Primary Key

        [Required]
        [StringLength(100)]
        public string ReportType { get; set; } = string.Empty; // Type of Report (e.g., Revenue, Occupancy, Feedback)

        public DateTime GeneratedDate { get; set; } = DateTime.Now; // Date when the report was generated

        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalRevenue { get; set; } // Total earnings (for financial reports)

        public int? TotalBookings { get; set; } // Count of total bookings (for occupancy reports)

        public int? TotalGuests { get; set; } // Total number of guests

        public int? TotalFeedbacks { get; set; } // Number of feedback entries collected

        public string Notes { get; set; } = string.Empty;// Additional remarks
    }
}
