using Mawgood.Core.IResponses.IResponseMessage;
using System.Linq.Expressions;





namespace Mawgood.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {

        // get methods
        Task<IEnumerable<IResponseMessage<T>>> GetAllAsync();
        Task<IResponseMessage<T>> GetByIdAsync(int id);
        Task<IEnumerable<IResponseMessage<T>>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task<IResponseMessage<T>> GetFirstAsync(Expression<Func<T, bool>> predicate);

        // add methods
        Task<IResponseMessage<T>> Add(T model);

        // update methods
        Task<IResponseMessage<T>> Update(T model);

        // delete method
        Task<IResponseMessage<T>> Delete(int id);

    }
}
