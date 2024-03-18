using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Application.Contracts.Persistence;

namespace UserExperience.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {


    }

}
