namespace VendorBiddingApp_Backend.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; }
        public string VendorName { get; set; }
        public DateTime Expiration { get; set; }
    }
}
