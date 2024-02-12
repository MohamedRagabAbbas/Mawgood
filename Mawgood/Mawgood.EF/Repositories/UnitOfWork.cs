using Mawgood.Core.IRepositories;
using Mawgood.Core.Models;
using Mawgood.EF.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Application = Mawgood.Core.Models.Application;

namespace Mawgood.EF.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            Employers = new GenericRepository<Employer>(_dbContext);
            JobSeekers = new GenericRepository<JobSeeker>(_dbContext);
            Jobs = new GenericRepository<Job>(_dbContext);
            Applications = new GenericRepository<Application>(_dbContext);
        }
        public IGenericRepository<Employer> Employers { get; private set; } 

        public IGenericRepository<JobSeeker> JobSeekers { get; private set; }

        public IGenericRepository<Job> Jobs { get; private set; }

        public IGenericRepository<Application> Applications { get; private set; }

        public int Complete()
        {
            return _dbContext.SaveChanges();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
