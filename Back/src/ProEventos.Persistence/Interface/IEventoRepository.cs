using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interface 
{
    public interface IEventoRepository
    {
        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante);
        Task<Evento[]> GetAllEventosAsync(string tema, bool incluirPalestrante);
        Task<Evento> GetAllEventosByIdAsync(int eventoId, bool incluirPalestrante);
    }
}