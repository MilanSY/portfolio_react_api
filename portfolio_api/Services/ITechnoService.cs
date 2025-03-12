using portfolio_api.Models;

namespace portfolio_api.Services;

public interface ITechnoService
{
    Task<IEnumerable<Techno>> GetAllTechnosAsync();
    Task<Techno> GetTechnoByIdAsync(string id);
    Task AddTechnoAsync(Techno techno);
    Task UpdateTechnoAsync(string id, Techno techno);
    Task DeleteTechnoAsync(string id);
}