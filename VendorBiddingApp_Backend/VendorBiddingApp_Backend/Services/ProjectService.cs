using Microsoft.EntityFrameworkCore;
using VendorBiddingApp_Backend.Data;
using VendorBiddingApp_Backend.DTOs;
using VendorBiddingApp_Backend.Interfaces;
using VendorBiddingApp_Backend.Models;

namespace VendorBiddingApp_Backend.Services
{
    public class ProjectService : IProjectService
    {
        private readonly ApplicationDbContext _context;

        public ProjectService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Project> CreateProjectAsync(ProjectDto projectDto)
        {
            var project = new Project
            {
                Title = projectDto.Title,
                Description = projectDto.Description,
                BidCount = 0,
                CreatedAt = DateTime.UtcNow
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> UpdateBidsCountAsync(int projectId)
        {
            var project = await GetProjectByIdAsync(projectId);
            if (project != null)
            {
                project.BidCount += 1;
                _context.Projects.Update(project);
                await _context.SaveChangesAsync();
                return project;
            }

            return null!;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.AsNoTracking().ToListAsync();
        }

        public async Task<Project?> GetProjectByIdAsync(int id)
        {
            return await _context.Projects.FindAsync(id);
        }
    }
}
