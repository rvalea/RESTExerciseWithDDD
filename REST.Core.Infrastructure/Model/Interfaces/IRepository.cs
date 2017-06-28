namespace REST.Core.Infrastructure.Model
{

    public interface IRepository
    {
    }

    public interface IRepository<T, TId> : IReadOnlyRepository<T, TId>
    {
        void Add(T entity);

        void Save(T entity);

        void Remove(T entity);
    }
}