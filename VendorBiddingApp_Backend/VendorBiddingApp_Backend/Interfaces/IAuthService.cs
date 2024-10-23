using VendorBiddingApp_Backend.DTOs;

namespace VendorBiddingApp_Backend.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDto> LoginAsync(LoginDto loginDto);
    }
}
