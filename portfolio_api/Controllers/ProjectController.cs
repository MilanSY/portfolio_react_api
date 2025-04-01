using Microsoft.AspNetCore.Mvc;
using portfolio_api.Models;
using portfolio_api.Services;

namespace portfolio_api.Controllers;


/// <summary>
/// Contrôleur pour gérer les opérations liées aux projets.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    /// <summary>
    /// Récupère tous les projets.
    /// </summary>
    /// <returns>Une liste de projets.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllProjectsAsync();
        return Ok(projects);
    }

    /// <summary>
    /// Récupère un projet par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant du projet.</param>
    /// <returns>Le projet correspondant.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        if (project == null)
        {
            return NotFound();
        }
        return Ok(project);
    }
/*
    /// <summary>
    /// Ajoute un nouveau projet.
    /// </summary>
    /// <param name="project">Les détails du projet à ajouter.</param>
    /// <returns>Le projet créé.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(Project project)
    {
        project.Id = Guid.NewGuid();
        await _projectService.AddProjectAsync(project);
        return CreatedAtAction(nameof(GetById), new { id = project.Id }, project);
    }

    /// <summary>
    /// Met à jour un projet existant.
    /// </summary>
    /// <param name="id">L'identifiant du projet à mettre à jour.</param>
    /// <param name="project">Les nouveaux détails du projet.</param>
    /// <returns>Aucun contenu.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Project project)
    {
        var existingProject = await _projectService.GetProjectByIdAsync(id);
        if (existingProject == null)
        {
            return NotFound();
        }
        await _projectService.UpdateProjectAsync(id, project);
        return NoContent();
    }

    /// <summary>
    /// Supprime un projet.
    /// </summary>
    /// <param name="id">L'identifiant du projet à supprimer.</param>
    /// <returns>Aucun contenu.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existingProject = await _projectService.GetProjectByIdAsync(id);
        if (existingProject == null)
        {
            return NotFound();
        }
        await _projectService.DeleteProjectAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Ajoute une technologie à un projet.
    /// </summary>
    /// <param name="projectId">L'identifiant du projet.</param>
    /// <param name="technoId">L'identifiant de la technologie à ajouter.</param>
    /// <returns>Aucun contenu.</returns>
    [HttpPost("{projectId}/technos/{technoId}")]
    public async Task<IActionResult> AddTechnoToProject(string projectId, string technoId)
    {
        await _projectService.AddTechnoToProjectAsync(projectId, technoId);
        return NoContent();
    }

    /// <summary>
    /// Supprime une technologie d'un projet.
    /// </summary>
    /// <param name="projectId">L'identifiant du projet.</param>
    /// <param name="technoId">L'identifiant de la technologie à supprimer.</param>
    /// <returns>Aucun contenu.</returns>
    [HttpDelete("{projectId}/technos/{technoId}")]
    public async Task<IActionResult> RemoveTechnoFromProject(string projectId, string technoId)
    {
        await _projectService.RemoveTechnoFromProjectAsync(projectId, technoId);
        return NoContent();
    }
    */
}
