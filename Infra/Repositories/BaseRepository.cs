using Domain.Interfaces.Repositories;

namespace Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly Context _context;

        public BaseRepository(Context context)
        {
            _context = context;
        }

        public IList<T> Get()
        {
            return _context.Set<T>().ToList();
        }

        public T? GetById(long id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}