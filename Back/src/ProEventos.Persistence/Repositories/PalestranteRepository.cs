using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;

namespace ProEventos.Persistence
{
    public class PalestranteRepository : BaseRepository, IPalestranteRepository
    {
        private readonly ProEventosContext _context;

        public PalestranteRepository(ProEventosContext context) : base(context)
        {
            this._context = context;
        }
        
        public async Task<Palestrante[]> GetAllPalestrantesAsync(string tema, bool incluirEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if(incluirEventos)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Eventos);

            return await query.ToArrayAsync();
        }

        public async Task<Palestrante> GetAllPalestrantesByIdAsync(int palestranteId, bool incluirEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if(incluirEventos)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Eventos);

            query = query.OrderBy(p => p.Id).Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool incluirEventos)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(e => e.RedesSociais);

            if(incluirEventos)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Eventos);

            query = query.OrderBy(p => p.Id).Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}