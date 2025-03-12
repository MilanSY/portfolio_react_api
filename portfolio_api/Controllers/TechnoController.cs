using Microsoft.AspNetCore.Mvc;
using portfolio_api.Models;
using portfolio_api.Services;

namespace portfolio_api.Controllers;

/// <summary>
/// Contrôleur pour gérer les opérations liées aux technologies.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class TechnoController : ControllerBase
{
    private readonly ITechnoService _technoService;

    public TechnoController(ITechnoService technoService)
    {
        _technoService = technoService;
    }

    /// <summary>
    /// Récupère toutes les technologies.
    /// </summary>
    /// <returns>Une liste de technologies.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var technos = await _technoService.GetAllTechnosAsync();
        return Ok(technos);
    }

    /// <summary>
    /// Récupère une technologie par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant de la technologie.</param>
    /// <returns>La technologie correspondante.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var techno = await _technoService.GetTechnoByIdAsync(id);
        if (techno == null)
        {
            return NotFound();
        }
        return Ok(techno);
    }

    /// <summary>
    /// Ajoute une nouvelle technologie.
    /// </summary>
    /// <param name="techno">Les détails de la technologie à ajouter.</param>
    /// <returns>La technologie créée.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(Techno techno)
    {
        techno.Id = Guid.NewGuid();
        await _technoService.AddTechnoAsync(techno);
        return CreatedAtAction(nameof(GetById), new { id = techno.Id }, techno);
    }

    /// <summary>
    /// Met à jour une technologie existante.
    /// </summary>
    /// <param name="id">L'identifiant de la technologie à mettre à jour.</param>
    /// <param name="techno">Les nouveaux détails de la technologie.</param>
    /// <returns>Aucun contenu.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Techno techno)
    {
        var existingTechno = await _technoService.GetTechnoByIdAsync(id);
        if (existingTechno == null)
        {
            return NotFound();
        }
        await _technoService.UpdateTechnoAsync(id, techno);
        return NoContent();
    }

    /// <summary>
    /// Supprime une technologie.
    /// </summary>
    /// <param name="id">L'identifiant de la technologie à supprimer.</param>
    /// <returns>Aucun contenu.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existingTechno = await _technoService.GetTechnoByIdAsync(id);
        if (existingTechno == null)
        {
            return NotFound();
        }
        await _technoService.DeleteTechnoAsync(id);
        return NoContent();
    }
}
