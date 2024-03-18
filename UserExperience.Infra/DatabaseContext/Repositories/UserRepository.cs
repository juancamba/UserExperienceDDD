using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Application.Contracts.Persistence;
using UserExperience.Domain;

namespace UserExperience.Infra.Persistence.DatabaseContext.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(WEDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsUserNameUnique(string name)
        {
            return await _context.Users.AnyAsync(u => u.UserName == name) == false;
        }
    }
}
