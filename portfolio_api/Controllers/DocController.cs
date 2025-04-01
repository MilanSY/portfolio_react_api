using Microsoft.AspNetCore.Mvc;
using portfolio_api.Models;
using portfolio_api.Services;

namespace portfolio_api.Controllers;

/// <summary>
/// Contrôleur pour gérer les opérations liées aux documents.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class DocController : ControllerBase
{
    private readonly IDocService _docService;

    public DocController(IDocService docService)
    {
        _docService = docService;
    }

    /// <summary>
    /// Récupère tous les documents.
    /// </summary>
    /// <returns>Une liste de documents.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var docs = await _docService.GetAllDocsAsync();
        return Ok(docs);
    }

    /// <summary>
    /// Récupère un document par son identifiant.
    /// </summary>
    /// <param name="id">L'identifiant du document.</param>
    /// <returns>Le document correspondant.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var doc = await _docService.GetDocByIdAsync(id);
        if (doc == null)
        {
            return NotFound();
        }
        return Ok(doc);
    }
/*
    /// <summary>
    /// Ajoute un nouveau document.
    /// </summary>
    /// <param name="doc">Les détails du document à ajouter.</param>
    /// <returns>Le document créé.</returns>
    [HttpPost]
    public async Task<IActionResult> Create(Doc doc)
    {
        doc.Id = Guid.NewGuid();
        await _docService.AddDocAsync(doc);
        return CreatedAtAction(nameof(GetById), new { id = doc.Id }, doc);
    }

    /// <summary>
    /// Met à jour un document existant.
    /// </summary>
    /// <param name="id">L'identifiant du document à mettre à jour.</param>
    /// <param name="doc">Les nouveaux détails du document.</param>
    /// <returns>Aucun contenu.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, Doc doc)
    {
        var existingDoc = await _docService.GetDocByIdAsync(id);
        if (existingDoc == null)
        {
            return NotFound();
        }
        await _docService.UpdateDocAsync(id, doc);
        return NoContent();
    }

    /// <summary>
    /// Supprime un document.
    /// </summary>
    /// <param name="id">L'identifiant du document à supprimer.</param>
    /// <returns>Aucun contenu.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        var existingDoc = await _docService.GetDocByIdAsync(id);
        if (existingDoc == null)
        {
            return NotFound();
        }
        await _docService.DeleteDocAsync(id);
        return NoContent();
    }
*/
}
