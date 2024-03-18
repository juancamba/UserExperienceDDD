using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserExperience.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Web { get; set; }

        public string Direccion { get; set; }
    }
}


