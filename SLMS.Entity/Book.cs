namespace SLMS.Entity
{
    public class Book
    {
        public int Id { get; set; }

        public string BookTitle { get; set; }

        public string ISBN { get; set; }

        public string PublishingYear { get; set; }

        public bool IsAvailable { get; set; }

        public double Price { get; set; }

        public User Borrower { get; set; }
    }
}