using System;

namespace oculus_sport.Models
{
    public class Booking
    {
        public string Id { get; set; } = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();

        // Initialized to empty strings to satisfy .NET 9 Null Safety
        public string UserId { get; set; } = string.Empty;

        public string FacilityName { get; set; } = string.Empty;
        public string FacilityImage { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;

        public DateTime Date { get; set; }
        public string TimeSlot { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending";

        public string ContactName { get; set; } = string.Empty;
        public string ContactStudentId { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;

        public string TotalCost { get; set; } = "Free";
    }
}