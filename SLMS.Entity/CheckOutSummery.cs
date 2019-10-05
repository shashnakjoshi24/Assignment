using System;

namespace SLMS.Entity
{
    public class CheckOutSummery
    {
        public int ID { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
        public DateTime CheckOutDate { get; set; }
        public DateTime CheckInDate { get; set; }
        public int NumberOfDays { get; set; }
        public bool IsOverDue { get; set; }
    }
}