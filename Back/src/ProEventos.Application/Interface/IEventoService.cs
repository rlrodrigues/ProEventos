using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Application.Interface
{
    public interface IEventoService
    {
        Task<Evento> AddEventos(Evento model);
        Task<Evento> UpdateEnvento(int eventoId, Evento model);
        Task<bool> DeleteEvento(int eventoId);

        Task<Evento[]> GetAllEventosByTemaAsync(string tema, bool incluirPalestrante);
        Task<Evento[]> GetAllEventosAsync(string tema, bool incluirPalestrante);
        Task<Evento> GetAllEventosByIdAsync(int eventoId, bool incluirPalestrante);
    }
}