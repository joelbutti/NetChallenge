
namespace NetChallenge.Domain.Abstractions
{
    public interface IRepository<T>
    {
        IEnumerable<T> AsEnumerable();

        void Add(T item);

        IEnumerable<T> AsEnumerableDb();

        Task AddDb(T item);
    }
}