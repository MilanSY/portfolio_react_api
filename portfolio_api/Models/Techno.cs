using System.ComponentModel.DataAnnotations;

namespace portfolio_api.Models;

public class Techno
{
    public Guid Id { get; set; }

    [Required]
    public string Img { get; set; }
    [Required]
    public string Name { get; set; }
    
    public string Url { get; set; }
    
    public DateTime Date { get; set; }
}
