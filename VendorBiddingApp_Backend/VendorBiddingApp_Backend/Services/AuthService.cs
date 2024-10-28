using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VendorBiddingApp_Backend.Data;
using VendorBiddingApp_Backend.DTOs;
using VendorBiddingApp_Backend.Interfaces;
using VendorBiddingApp_Backend.Models;
using VendorBiddingApp_Backend.Utilities;

namespace VendorBiddingApp_Backend.Services
{
    public class AuthService : IAuthService
    {
        private readonly JwtTokenGenerator _jwtTokenGenerator;
        private readonly UserManager<Vendor> _userManager;
        private readonly SignInManager<Vendor> _signInManager;

        public AuthService(JwtTokenGenerator jwtTokenGenerator, UserManager<Vendor> userManager, SignInManager<Vendor> signInManager)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthResponseDto> LoginAsync(LoginDto loginDto)
        {
            var vendor = await _userManager.FindByEmailAsync(loginDto.Email);

            if (vendor == null)
            {
                throw new UnauthorizedAccessException("Invalid email or password.");
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(vendor, loginDto.Password, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
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
