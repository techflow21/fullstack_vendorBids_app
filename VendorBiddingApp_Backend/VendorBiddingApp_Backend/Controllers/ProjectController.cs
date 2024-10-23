using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using VendorBiddingApp_Backend.DTOs;
using VendorBiddingApp_Backend.Interfaces;
using VendorBiddingApp_Backend.Models;

namespace VendorBiddingApp_Backend.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "Add a new project.")]
        public async Task<IActionResult> CreateProject([FromBody] ProjectDto projectDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var project = await _projectService.CreateProjectAsync(projectDto);
            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Fetch all projects.")]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects()
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        }
     
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Fetch a project.")]
        public async Task<ActionResult<Project>> GetProject(int id)
        {
            var project = await _projectService.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }
    }
}
