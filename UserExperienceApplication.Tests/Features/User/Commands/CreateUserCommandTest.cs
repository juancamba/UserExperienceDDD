using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Application.Contracts.Logging;
using UserExperience.Application.Contracts.Persistence;
using UserExperience.Application.Exceptions;
using UserExperience.Application.Features.User.Commands.CreateUser;
using UserExperience.Application.Features.User.Queries.GetAllUsers;
using UserExperience.Application.MappingProfiles;
using UserExperienceApplication.Tests.Mocks;

namespace UserExperienceApplication.Tests.Features.User.Commands
{
    public class CreateUserCommandTest
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly Mock<IAppLogger<GetAllUsersQueryHandler>> _mockAppLogger;

        public CreateUserCommandTest()
        {
            _mockRepo = MockUserRepository.GetUserMockRepository();
            //agregamos mapper config
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<UserProfile>();
            });
            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetAllUsersQueryHandler>>();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateUserCommandHandler(_mapper, _mockRepo.Object);
            // expects BadRequestException

            //await handler.Handle(new CreateUserCommand() { UserName = "juancamba" }, CancellationToken.None);


            Assert.ThrowsAsync<BadRequestException>(() => handler.Handle(new CreateUserCommand() { UserName = "juancamba" }, CancellationToken.None));
            /*
            var result = await _mockRepo.Object.GetAsync();
            Assert.NotNull(result);
            Assert.IsType<List<UserDto>>(result);
            Assert.Equal(3, result.Count);
            */
        }

    }
}
