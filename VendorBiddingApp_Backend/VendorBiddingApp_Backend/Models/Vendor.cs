using Microsoft.AspNetCore.Identity;

namespace VendorBiddingApp_Backend.Models
{
    public class Vendor : IdentityUser
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
