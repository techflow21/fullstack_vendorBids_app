namespace VendorBiddingApp_Backend.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int BidCount { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
