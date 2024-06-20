using Microsoft.EntityFrameworkCore;
using ToolsMenagement.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolsMenagement.Models;

namespace ToolsMenagement.Repositories
{
    public class ToolRepository : IToolRepository
    {
        private readonly ToolsBaseContext _context;
        public ToolRepository(ToolsBaseContext context)
        {
            _context = context;
        }

        public async Task AddNarzedzieAsync(Narzedzie narzedzie)
        {
            _context.Narzedzies.Add(narzedzie);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Kategorium>> GetKategorieAsync()
        {
            return await _context.Kategoria.ToListAsync();
        }

        public async Task<IEnumerable<Narzedzie>> GetNarzedziaAsync()
        {
            return await _context.Narzedzies
        .Include(n => n.IdKategoriiNavigation)
        .ToListAsync();
        }

        public async Task<IEnumerable<Narzedzie>> GetNarzedziaWithMagazynAsync()
        {
            return await _context.Narzedzies
                .Include(n => n.IdKategoriiNavigation)
                .Include(n => n.Magazyns)
                .ToListAsync();
        }
    }
}
