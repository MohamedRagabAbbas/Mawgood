using Mawgood.Core.IResponses.IResponseMessage;
using System.Linq.Expressions;





namespace Mawgood.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {

        // get methods
        Task<IResponseMessage<IEnumerable<T>>> GetAllAsync();
        Task<IResponseMessage<T>> GetByIdAsync(int id);
        Task<IResponseMessage<IEnumerable<T>>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task<IResponseMessage<T>> GetFirstAsync(Expression<Func<T, bool>> predicate);

        // add methods
        Task<IResponseMessage<T>> Add(T model);
        Task AppRanage(List<T> models);

        // update methods
        IResponseMessage<T> Update(T model);
        void UpdateRanage(List<T> models);

        // delete method
        Task<IResponseMessage<T>> Delete(int id);
        Task<IResponseMessage<IEnumerable<T>>> DeleteRange(List<int> ids);

    }
}
