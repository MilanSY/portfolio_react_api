using System.ComponentModel.DataAnnotations;

namespace portfolio_api.Models;


public class Doc
{
    public Guid Id { get; set; }

    [Required]
    public string? Name { get; set; }

    [Required]
    public string? Url { get; set; }
    
    [Required]
    public Guid ProjectId { get; set; }
}
