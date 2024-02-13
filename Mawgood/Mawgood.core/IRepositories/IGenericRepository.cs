using Mawgood.Core.DTO.Response;
using System.Linq.Expressions;





namespace Mawgood.Core.IRepositories
{
    public interface IGenericRepository<T> where T : class
    {

        // get methods
        Task<ResponseMessage<IEnumerable<T>>> GetAllAsync();
        Task<ResponseMessage<T>> GetByIdAsync(int id);
        Task<ResponseMessage<IEnumerable<T>>> GetWhereAsync(Expression<Func<T, bool>> predicate);
        Task<ResponseMessage<T>> GetFirstAsync(Expression<Func<T, bool>> predicate);

        // add methods
        Task<ResponseMessage<T>> Add(T model);
        Task AppRanage(List<T> models);

        // update methods
        ResponseMessage<T> Update(T model);
        void UpdateRanage(List<T> models);

        // delete method
        Task<ResponseMessage<T>> Delete(int id);
        Task<ResponseMessage<IEnumerable<T>>> DeleteRange(List<int> ids);

    }
}
