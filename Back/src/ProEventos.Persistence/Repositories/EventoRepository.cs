using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Interface;

namespace ProEventos.Persistence
{
    public class EventoRepository : BaseRepository, IEventoRepository
    {
        private readonly ProEventosContext _context;

        public EventoRepository(ProEventosContext context) : base(context)
        {
            this._context = context;
        }
        
        public async Task<Evento[]> GetAllEventosAsync(string tema, bool incluirPalestrante)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if(incluirPalestrante)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrantes);

            return await query.ToArrayAsync();
        }

        public async Task<Evento> GetAllEventosByIdAsync(int eventoId, bool incluirPalestrante)
        {
            IQueryable<Evento> query = _context.Eventos.Include(e => e.Lotes).Include(e => e.RedesSociais);

            if(incluirPalestrante)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrantes);

            query = query.OrderBy(e => e.Id).Where(e => e.Id == eventoId);
            
            return await query.FirstOrDefaultAsync();
        }

        public async Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(e => e.Lotes)
                .Include(e => e.RedesSociais);

            if(incluirPalestrante)
                query = query.Include(e => e.PalestrantesEventos).ThenInclude(pe => pe.Palestrantes);

            query = query.OrderBy(e => e.Id)
                .Where(e => e.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
    }
}