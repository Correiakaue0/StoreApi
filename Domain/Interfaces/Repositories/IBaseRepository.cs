namespace Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        void Create(T entity);
        void Delete(T entity);
        IList<T> Get();
        T? GetById(long id);
        void Update(T entity);
    }
}