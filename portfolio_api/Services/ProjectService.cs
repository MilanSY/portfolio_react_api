using portfolio_api.Models;
using portfolio_api.Storage;

namespace portfolio_api.Services;

public class ProjectService : IProjectService
{
    private readonly IProjectStorage _projectStorage;

    public ProjectService(IProjectStorage projectStorage)
    {
        _projectStorage = projectStorage;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync()
    {
        return await _projectStorage.GetAllAsync();
    }

    public async Task<Project> GetProjectByIdAsync(string id)
    {
        return await _projectStorage.GetByIdAsync(id);
    }

    public async Task AddProjectAsync(Project project)
    {
        await _projectStorage.AddAsync(project);
    }

    public async Task UpdateProjectAsync(string id, Project project)
    {
        await _projectStorage.UpdateAsync(id, project);
    }

    public async Task DeleteProjectAsync(string id)
    {
        await _projectStorage.DeleteAsync(id);
    }

    public async Task AddTechnoToProjectAsync(string projectId, string technoId)
    {
        await _projectStorage.AddTechnoToProjectAsync(projectId, technoId);
    }

    public async Task RemoveTechnoFromProjectAsync(string projectId, string technoId)
    {
        await _projectStorage.RemoveTechnoFromProjectAsync(projectId, technoId);
    }
}