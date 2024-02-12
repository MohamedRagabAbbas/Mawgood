using Mawgood.Core.IRepositories;
using Mawgood.Core.IResponses.IResponseMessage;
using Mawgood.EF.DB;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.EF.Repositories
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }

        public Task<IEnumerable<IResponseMessage<T>>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IResponseMessage<T>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseMessage<T>> GetFirstAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<IResponseMessage<T>>> GetWhereAsync(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }


        public Task<IResponseMessage<T>> Add(T model)
        {
            throw new NotImplementedException();
        }
        public Task<IResponseMessage<T>> Update(T model)
        {
            throw new NotImplementedException();
        }

        public Task<IResponseMessage<T>> Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
