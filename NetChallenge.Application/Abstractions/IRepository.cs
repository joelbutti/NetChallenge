
namespace NetChallenge.Application.Abstractions
{
    public interface IRepository<T>
    {
        IEnumerable<T> AsEnumerable();

        Task Add(T item);
    }
}