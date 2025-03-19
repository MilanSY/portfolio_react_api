using System.ComponentModel.DataAnnotations;

namespace portfolio_api.Models;

public class Project
{
    public Guid Id { get; set; }

    [Required]

    public string? Name { get; set; }

    public string? Url { get; set; }

    [Required]
    public string? Img { get; set; }


    [Required]
    public string? Description { get; set; }


    public string? Github { get; set; }
    
    public DateTime? Date { get; set; }


    public List<Techno> Technos { get; set; } = new List<Techno>();

    public List<Doc> Docs { get; set; } = new List<Doc> { new Doc() };
}