using VendorBiddingApp_Backend.DTOs;
using VendorBiddingApp_Backend.Models;

namespace VendorBiddingApp_Backend.Interfaces
{
    public interface IProjectService
    {
        Task<Project> CreateProjectAsync(ProjectDto projectDto);
        Task<Project> UpdateBidsCountAsync(int projectId);
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project?> GetProjectByIdAsync(int id);
    }
}
