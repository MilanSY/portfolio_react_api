using portfolio_api.Models;
using portfolio_api.Storage;

namespace portfolio_api.Services;

public class DocService : IDocService
{
    private readonly IDocStorage _docStorage;

    public DocService(IDocStorage docStorage)
    {
        _docStorage = docStorage;
    }

    public async Task<IEnumerable<Doc>> GetAllDocsAsync()
    {
        return await _docStorage.GetAllAsync();
    }

    public async Task<Doc> GetDocByIdAsync(string id)
    {
        return await _docStorage.GetByIdAsync(id);
    }

    public async Task AddDocAsync(Doc doc)
    {
        await _docStorage.AddAsync(doc);
    }

    public async Task UpdateDocAsync(string id, Doc doc)
    {
        await _docStorage.UpdateAsync(id, doc);
    }

    public async Task DeleteDocAsync(string id)
    {
        await _docStorage.DeleteAsync(id);
    }
}
