using Microsoft.EntityFrameworkCore;
using VendorBiddingApp_Backend.Data;
using VendorBiddingApp_Backend.DTOs;
using VendorBiddingApp_Backend.Interfaces;
using VendorBiddingApp_Backend.Models;

namespace VendorBiddingApp_Backend.Services
{
    public class VendorService : IVendorService
    {
        private readonly ApplicationDbContext _context;

        public VendorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Vendor> CreateVendorAsync(VendorDto vendorDto)
        {
            // Check if email already exists
            if (await _context.Vendors.AnyAsync(v => v.Email == vendorDto.Email))
            {
                throw new Exception("Email already in use.");
            }

            var vendor = new Vendor
            {
                Name = vendorDto.Name,
                Email = vendorDto.Email,
                CreatedAt = DateTime.UtcNow,
                Password = BCrypt.Net.BCrypt.HashPassword(vendorDto.Password)
            };

             _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();
            return vendor;
        }

        public async Task<Vendor?> GetVendorAsync(int id)
        {
            return  await _context.Vendors.FindAsync(id);
        }
    }

}
