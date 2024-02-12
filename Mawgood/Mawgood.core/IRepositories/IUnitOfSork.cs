using Mawgood.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.Core.IRepositories
{
    public interface IUnitOfWork:IDisposable
    {
        IGenericRepository<Employer> Employers { get; }
        IGenericRepository<JobSeeker> JobSeekers { get; }
        IGenericRepository<Job> Jobs { get; }
        IGenericRepository<Application> Applications { get; }

        int Complete();


    }
}
