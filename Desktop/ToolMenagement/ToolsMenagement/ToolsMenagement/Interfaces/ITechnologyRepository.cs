using ToolsMenagement.Models;

namespace ToolsMenagement.Interfaces
{
    public interface ITechnologyRepository
    {
        Task AddTechnologyAsync(Technologium technologia);
        Task<IEnumerable<Technologium>> GetTechnologiesAsync();
        Task<Technologium> GetTechnologyByIdAsync(int id);
    }
}
