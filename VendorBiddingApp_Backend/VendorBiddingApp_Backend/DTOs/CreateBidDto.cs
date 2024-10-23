using System.ComponentModel.DataAnnotations;

namespace VendorBiddingApp_Backend.DTOs
{
    public class CreateBidDto
    {
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Bid amount must be greater than 0.")]
        public decimal Amount { get; set; }
    }
}
