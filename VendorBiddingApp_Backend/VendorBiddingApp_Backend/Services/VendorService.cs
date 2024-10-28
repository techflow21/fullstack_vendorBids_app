using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using VendorBiddingApp_Backend.Data;
using VendorBiddingApp_Backend.DTOs;
using VendorBiddingApp_Backend.Interfaces;
using VendorBiddingApp_Backend.Models;

namespace VendorBiddingApp_Backend.Services
{
    public class VendorService : IVendorService
    {
        private readonly UserManager<Vendor> _userManager;

        public VendorService(UserManager<Vendor> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Vendor> CreateVendorAsync(VendorDto vendorDto)
        {
            // Check if email already exists
            var existingUser = await _userManager.FindByEmailAsync(vendorDto.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already in use.");
            }

            var vendor = new Vendor
            {
                UserName = vendorDto.Email,
                Email = vendorDto.Email,
                Name = vendorDto.Name,
                CreatedAt = DateTime.UtcNow
            };

            var result = await _userManager.CreateAsync(vendor, vendorDto.Password);

            if (!result.Succeeded)
            {
                throw new Exception($"Error creating vendor");
            }

            return vendor;
        }

        public async Task<Vendor?> GetVendorAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }

}
