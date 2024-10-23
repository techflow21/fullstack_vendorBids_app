using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VendorBiddingApp_Backend.DTOs;
using VendorBiddingApp_Backend.Interfaces;

namespace VendorBiddingApp_Backend.Controllers
{
    [Route("api/vendors")]
    [ApiController]
    public class VendorController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add new vendor")]
        public async Task<IActionResult> CreateVendor([FromBody] VendorDto vendorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var vendor = await _vendorService.CreateVendorAsync(vendorDto);
            return CreatedAtAction(nameof(GetVendor), new { id = vendor.Id }, vendor);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Fetch a vendor")]
        public async Task<IActionResult> GetVendor(int id)
        {
            var vendor = await _vendorService.GetVendorAsync(id);
            if (vendor == null)
                return NotFound();

            return Ok(vendor);
        }
    }
}
