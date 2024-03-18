using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserExperience.Application.Features.Workingexperience.Commands.CreateWorkingexperience
{
    public class CreateWorkingexperienceCommand : IRequest<Unit>
    {
        public int UserId { get; set; }
    }
}
