using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Application.Features.User.Commands.CreateUser;
using UserExperience.Application.Features.User.Queries.GetAllUsers;
using UserExperience.Domain;

namespace UserExperience.Application.MappingProfiles
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UserDto, User>().ReverseMap();
        }
    }
}
