using portfolio_api.Models;

namespace portfolio_api.Storage;
public interface ITechnoStorage
{
    Task<IEnumerable<Techno>> GetAllAsync();
    Task<Techno> GetByIdAsync(string id);
    Task AddAsync(Techno techno);
    Task UpdateAsync(string id, Techno techno);
    Task DeleteAsync(string id);
}
