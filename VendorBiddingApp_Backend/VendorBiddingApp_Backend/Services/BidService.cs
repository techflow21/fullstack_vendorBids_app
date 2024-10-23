using Microsoft.EntityFrameworkCore;
using VendorBiddingApp_Backend.Data;
using VendorBiddingApp_Backend.DTOs;
using VendorBiddingApp_Backend.Interfaces;
using VendorBiddingApp_Backend.Models;

namespace VendorBiddingApp_Backend.Services
{
    public class BidService : IBidService
    {
        private readonly ApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IProjectService _projectService;

        public BidService(ApplicationDbContext context, IProjectService projectService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _projectService = projectService;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Bid> SubmitBidAsync(CreateBidDto createBidDto, int projectId)
        {
            // get VendorId from JWT
            var vendorId = _httpContextAccessor.HttpContext?.User.FindFirst("VendorId")?.Value;
            if (vendorId == null)
            {
                throw new UnauthorizedAccessException("VendorId not found in the token.");
            }

            var bid = new Bid
            {
                ProjectId = projectId,
                VendorId = int.Parse(vendorId),
                Amount = createBidDto.Amount,
                SubmittedAt = DateTime.UtcNow
            };
                     
            await _context.Bids.AddAsync(bid);
            var result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                var projectToUpdate = await _projectService.GetProjectByIdAsync(projectId);
                if (projectToUpdate != null)
                {
                   await _projectService.UpdateBidsCountAsync(projectId);
                }

                return bid;
            }
            return null!;
        }

 
        public async Task<IEnumerable<Bid>> GetBidsByVendorAsync()
        {
            // get VendorId from JWT
            var vendorId = _httpContextAccessor.HttpContext?.User.FindFirst("VendorId")?.Value;
            if (String.IsNullOrEmpty(vendorId))
            {
                throw new UnauthorizedAccessException("Vendor Id not found in the token.");
            }

            var bids = await _context.Bids.Where(b => b.VendorId.ToString() == vendorId)
                .Include(b => b.Project).ToListAsync();

            return bids!;
        }
    }
}
