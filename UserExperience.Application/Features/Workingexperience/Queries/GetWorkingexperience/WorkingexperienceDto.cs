using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserExperience.Application.Features.Workingexperience.Queries.GetWorkingexperience
{
    public class WorkingexperienceDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Details { get; set; }

        public string Environment { get; set; }
    }
}
