using portfolio_api.Models;

namespace portfolio_api.Storage;

public interface IDocStorage
{
    Task<IEnumerable<Doc>> GetAllAsync();
    Task<Doc> GetByIdAsync(string id);
    Task AddAsync(Doc doc);
    Task UpdateAsync(string id, Doc doc);
    Task DeleteAsync(string id);
}
