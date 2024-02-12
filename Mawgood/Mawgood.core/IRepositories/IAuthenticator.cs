using Mawgood.Core.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mawgood.Core.IRepositories
{
    public interface IAuthenticator:IGenericRepository<User>
    {
        
    }
}
