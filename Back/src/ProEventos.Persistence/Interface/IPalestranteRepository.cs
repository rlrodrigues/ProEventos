using System.Threading.Tasks;
using ProEventos.Domain;

namespace ProEventos.Persistence.Interface 
{
    public interface IPalestranteRepository
    {  
        Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string tema, bool incluirEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(string tema, bool incluirEventos);
        Task<Palestrante> GetAllPalestrantesByIdAsync(int palestranteId, bool incluirEventos);
    }
}