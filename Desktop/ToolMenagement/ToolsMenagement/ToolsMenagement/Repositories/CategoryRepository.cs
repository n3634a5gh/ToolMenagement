using Microsoft.EntityFrameworkCore;
using ToolsMenagement.Interfaces;
using ToolsMenagement.Models;

namespace ToolsMenagement.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        private readonly ToolsBaseContext _context;

        public CategoryRepository(ToolsBaseContext context)
        {
            _context = context;
        }

        public async Task AddCategoryAsync(Kategorium kategoria)
        {
            _context.Kategoria.Add(kategoria);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Kategorium>> GetCategoryAsync()
        {
            return await _context.Kategoria.ToListAsync();
        }
    }
}
