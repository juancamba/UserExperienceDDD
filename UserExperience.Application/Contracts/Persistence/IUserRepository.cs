using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Domain;

namespace UserExperience.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<bool> IsUserNameUnique(string name);
    }
}
