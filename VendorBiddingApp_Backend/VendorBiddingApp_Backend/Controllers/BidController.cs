using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VendorBiddingApp_Backend.DTOs;
using VendorBiddingApp_Backend.Interfaces;

namespace VendorBiddingApp_Backend.Controllers
{
    [Route("api/bids")]
    [ApiController]
    [Authorize]
    public class BidController : ControllerBase
    {
        private readonly IBidService _bidService;

        public BidController(IBidService bidService)
        {
            _bidService = bidService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Bid on a project")]
        public async Task<IActionResult> SubmitBid([FromBody] CreateBidDto createBidDto, int projectId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bid = await _bidService.SubmitBidAsync(createBidDto, projectId);
            return CreatedAtAction(nameof(GetBidsByVendor), new { vendorId = bid.VendorId }, bid);
        }


        [HttpGet]
        [SwaggerOperation(Summary = "Get current vendor bids")]
        public async Task<IActionResult> GetBidsByVendor()
        {
            var bids = await _bidService.GetBidsByVendorAsync();
            return Ok(bids);
        }
    }
}
