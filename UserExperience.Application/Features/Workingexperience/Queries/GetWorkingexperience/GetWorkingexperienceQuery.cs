using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace UserExperience.Application.Features.Workingexperience.Queries.GetWorkingexperience
{
    public record GetWorkingexperienceQuery(int userId) : IRequest<List<WorkingexperienceDto>>
    {
    }

}
