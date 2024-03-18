using AutoMapper;
using MediatR;
using UserExperience.Application.Contracts.Logging;
using UserExperience.Application.Contracts.Persistence;

namespace UserExperience.Application.Features.User.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IAppLogger<GetAllUsersQueryHandler> _logger;

        public GetAllUsersQueryHandler(IMapper mapper, IUserRepository userRepository, IAppLogger<GetAllUsersQueryHandler> logger)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _logger = logger;
        }


        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            // query db
            var users = await _userRepository.GetAsync();


            _logger.LogInformation("All Users Retrieved");
            var data = _mapper.Map<List<UserDto>>(users);

            return data;
        }
    }

}
