using portfolio_api.Models;

namespace portfolio_api.Storage;

public interface IProjectStorage
{
    Task<IEnumerable<Project>> GetAllAsync();
    Task<Project> GetByIdAsync(string id);
    Task AddAsync(Project project);
    Task UpdateAsync(string id, Project project);
    Task DeleteAsync(string id);
    Task AddTechnoToProjectAsync(string projectId, string technoId);
    Task RemoveTechnoFromProjectAsync(string projectId, string technoId);
}