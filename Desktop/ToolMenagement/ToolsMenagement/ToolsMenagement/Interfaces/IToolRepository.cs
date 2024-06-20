using ToolsMenagement.Models;
using System.Collections.Generic;                                                                                                                                       

namespace ToolsMenagement.Interfaces
{
    public interface IToolRepository
    {
        Task AddNarzedzieAsync(Narzedzie narzedzie);
        Task<IEnumerable<Narzedzie>> GetNarzedziaAsync();
        Task<IEnumerable<Kategorium>> GetKategorieAsync();
        Task<IEnumerable<Narzedzie>> GetNarzedziaWithMagazynAsync();
    }
}
