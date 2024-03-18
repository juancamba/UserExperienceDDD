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
    public class WorkingexperienceRepository : GenericRepository<Workingexperience>, IWorkingexperienceRepository
    {
        public WorkingexperienceRepository(WEDatabaseContext context) : base(context)
        {
        }

        public async Task AddWorkingexperiences(List<Workingexperience> workingexperiences)
        {
            await _context.AddRangeAsync(workingexperiences);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Workingexperience>> GetWorkingexperiencesByUserId(int userId)
        {
            var allWorkingexperiences = await _context.Workingexperiences.Where(x => x.UserId == userId).ToListAsync();
            return allWorkingexperiences;
        }
    }
}
