using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Domain;

namespace UserExperience.Application.Contracts.Persistence
{
    public interface IWorkingexperienceRepository : IGenericRepository<Workingexperience>
    {
        Task AddWorkingexperiences(List<Workingexperience> workingexperiences);
        Task<List<Workingexperience>> GetWorkingexperiencesByUserId(int userId);
    }
}
