using portfolio_api.Models;

namespace portfolio_api.Services;

public interface IProjectService
{
    Task<IEnumerable<Project>> GetAllProjectsAsync();
    Task<Project> GetProjectByIdAsync(string id);
    Task AddProjectAsync(Project project);
    Task UpdateProjectAsync(string id, Project project);
    Task DeleteProjectAsync(string id);
    Task AddTechnoToProjectAsync(string projectId, string technoId);
    Task RemoveTechnoFromProjectAsync(string projectId, string technoId); 
}