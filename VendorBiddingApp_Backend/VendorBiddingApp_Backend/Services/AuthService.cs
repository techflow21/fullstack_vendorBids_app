using Microsoft.EntityFrameworkCore;
using VendorBiddingApp_Backend.Data;
using VendorBiddingApp_Backend.DTOs;
using VendorBiddingApp_Backend.Interfaces;
using VendorBiddingApp_Backend.Utilities;

namespace VendorBiddingApp_Backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly JwtTokenGenerator _jwtTokenGenerator;

        public AuthService(ApplicationDbContext context, JwtTokenGenerator jwtTokenGenerator)
        {
            _context = context;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var vendor = await _context.Vendors
                .SingleOrDefaultAsync(v => v.Email == loginDto.Email);

            if (vendor == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, vendor.Password))
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            // Generate JWT Token
            var token = _jwtTokenGenerator.GenerateJwtToken(vendor);

            return new AuthResponseDto
            {
                Token = token,
                VendorName = vendor.Name,
                Expiration = DateTime.UtcNow.AddHours(1)
            };
        }       
    }
}
