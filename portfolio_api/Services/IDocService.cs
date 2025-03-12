using portfolio_api.Models;

namespace portfolio_api.Services;

public interface IDocService
{
    Task<IEnumerable<Doc>> GetAllDocsAsync();
    Task<Doc> GetDocByIdAsync(string id);
    Task AddDocAsync(Doc doc);
    Task UpdateDocAsync(string id, Doc doc);
    Task DeleteDocAsync(string id);
}