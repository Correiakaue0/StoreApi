using Domain.Interfaces.Repositories;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        public readonly Context _context;
        private readonly ILogger<T> _logger;

        public BaseRepository(Context context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<T> Get()
        {
            LogWithContext($"Ação de consulta executada na entidade {typeof(T).Name}", typeof(T).Name, nameof(Get));
            return _context.Set<T>().ToList();
        }

        public T? GetById(long id)
        {
            LogWithContext($"Ação de consulta por Id executada na entidade {typeof(T).Name}", typeof(T).Name, nameof(GetById));
            return _context.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            LogWithContext($"Ação de criação executada na entidade {typeof(T).Name}", typeof(T).Name, nameof(Create));
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            LogWithContext($"Ação de atualização executada na entidade {typeof(T).Name}", typeof(T).Name, nameof(Update));
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            LogWithContext($"Ação de deleção executada na entidade {typeof(T).Name}", typeof(T).Name, nameof(Delete));
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        private void LogWithContext(string message, string entityName, string method)
        {
            using (LogContext.PushProperty("EntityName", entityName))
            using (LogContext.PushProperty("Method", method))
                _logger.LogInformation(message);
        }
    }
}