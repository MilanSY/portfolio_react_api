using portfolio_api.Models;
using portfolio_api.Storage;

namespace portfolio_api.Services;

public class TechnoService : ITechnoService
{
    private readonly ITechnoStorage _technoStorage;

    public TechnoService(ITechnoStorage technoStorage)
    {
        _technoStorage = technoStorage;
    }

    public async Task<IEnumerable<Techno>> GetAllTechnosAsync()
    {
        return await _technoStorage.GetAllAsync();
    }

    public async Task<Techno> GetTechnoByIdAsync(string id)
    {
        return await _technoStorage.GetByIdAsync(id);
    }

    public async Task AddTechnoAsync(Techno techno)
    {
        await _technoStorage.AddAsync(techno);
    }

    public async Task UpdateTechnoAsync(string id, Techno techno)
    {
        await _technoStorage.UpdateAsync(id, techno);
    }

    public async Task DeleteTechnoAsync(string id)
    {
        await _technoStorage.DeleteAsync(id);
    }
}
