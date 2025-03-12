using System.ComponentModel.DataAnnotations;

namespace portfolio_api.Models;

public class Project
{
    public Guid Id { get; set; }

    [Required]

    public string Name { get; set; }

    [Required]
    public string Url { get; set; }

    [Required]
    public string Img { get; set; }


    [Required]
    public string Description { get; set; }

    [Required]
    public List<Techno> Technos { get; set; } = new List<Techno>();
}