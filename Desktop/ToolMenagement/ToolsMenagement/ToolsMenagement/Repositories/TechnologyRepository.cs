using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToolsMenagement.Interfaces;

namespace ToolsMenagement.Models
{
    public class TechnologyRepository:ITechnologyRepository
    {
        private readonly ToolsBaseContext _context;

        public TechnologyRepository(ToolsBaseContext context)
        {
            _context = context;
        }

        public async Task AddTechnologyAsync(Technologium technologia)
        {
            _context.Technologia.Add(technologia);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Technologium>> GetTechnologiesAsync()
        {
            return await _context.Technologia
                .Include(t => t.NarzedziaTechnologia)
                .ThenInclude(nt => nt.IdNarzedziaNavigation)
                .ToListAsync();
        }

        public async Task<Technologium> GetTechnologyByIdAsync(int id)
        {
            return await _context.Technologia
                .Include(t => t.NarzedziaTechnologia)
                .ThenInclude(nt => nt.IdNarzedziaNavigation)
                .FirstOrDefaultAsync(t => t.IdTechnologi == id);
        }
    }
}