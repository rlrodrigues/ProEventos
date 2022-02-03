using System.Threading.Tasks;
using ProEventos.Persistence.Interface;

namespace ProEventos.Persistence
{
    public class BaseRepository : IBaseRepository
    {
        private readonly ProEventosContext _context;

        public BaseRepository(ProEventosContext context)
        {
            this._context = context;
        }
        
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void DeleteRange<T>(T[] entity) where T : class
        {
            _context.RemoveRange(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

    }
}