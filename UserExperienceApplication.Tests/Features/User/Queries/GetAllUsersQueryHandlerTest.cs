using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Application.Contracts.Logging;
using UserExperience.Application.Contracts.Persistence;
using UserExperience.Application.Features.User.Queries.GetAllUsers;
using UserExperience.Application.MappingProfiles;
using UserExperienceApplication.Tests.Mocks;

namespace UserExperienceApplication.Tests.Features.User.Queries
{
    public class GetAllUsersQueryHandlerTest
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private readonly IMapper _mapper;
        private readonly Mock<IAppLogger<GetAllUsersQueryHandler>> _mockAppLogger;


        public GetAllUsersQueryHandlerTest()
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
        public async Task GetAllUsersTest()
        {
            var handler = new GetAllUsersQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);
            var result = await handler.Handle(new GetAllUsersQuery(), new System.Threading.CancellationToken());
            Assert.NotNull(result);
            Assert.IsType<List<UserDto>>(result);
            Assert.Equal(2, result.Count);
        }
    }
}
