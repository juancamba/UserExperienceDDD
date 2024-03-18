using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Application.Features.Workingexperience.Queries.GetWorkingexperience;

namespace UserExperience.Application.MappingProfiles
{
    public class WorkingexperienceProfile : Profile
    {
        public WorkingexperienceProfile()
        {

            CreateMap<Domain.Workingexperience, WorkingexperienceDto>().ReverseMap();


        }
    }
}
