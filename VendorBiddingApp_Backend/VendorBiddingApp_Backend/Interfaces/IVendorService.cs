using VendorBiddingApp_Backend.DTOs;
using VendorBiddingApp_Backend.Models;

namespace VendorBiddingApp_Backend.Interfaces
{
    public interface IVendorService
    {
        Task<Vendor> CreateVendorAsync(VendorDto vendorDto);
        Task<Vendor?> GetVendorAsync(int id);
    }
}
