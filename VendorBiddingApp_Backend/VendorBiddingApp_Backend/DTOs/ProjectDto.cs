using System.ComponentModel.DataAnnotations;

namespace VendorBiddingApp_Backend.DTOs
{
    public class ProjectDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Project title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Project description cannot be longer than 250 characters.")]
        public string Description { get; set; }
    }
}
