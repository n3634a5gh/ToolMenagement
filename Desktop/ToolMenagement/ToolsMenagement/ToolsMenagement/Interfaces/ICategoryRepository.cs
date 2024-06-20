using ToolsMenagement.Models;

namespace ToolsMenagement.Interfaces
{
    public interface ICategoryRepository
    {
        Task AddCategoryAsync(Kategorium kategoria);
        Task<IEnumerable<Kategorium>> GetCategoryAsync();
    }
}
