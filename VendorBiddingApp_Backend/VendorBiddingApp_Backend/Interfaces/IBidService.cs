using VendorBiddingApp_Backend.DTOs;
using VendorBiddingApp_Backend.Models;

namespace VendorBiddingApp_Backend.Interfaces
{
    public interface IBidService
    {
        Task<Bid> SubmitBidAsync(CreateBidDto createBidDto, int projectId);
        Task<IEnumerable<Bid>> GetBidsByVendorAsync();
    }
}
