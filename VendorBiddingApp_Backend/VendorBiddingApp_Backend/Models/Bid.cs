namespace VendorBiddingApp_Backend.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }

        public string VendorId { get; set; }
        public Vendor Vendor { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }

        public DateTime SubmittedAt { get; set; }
    }
}
