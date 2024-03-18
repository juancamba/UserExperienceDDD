using AutoMapper;
using MediatR;

using UserExperience.Application.Contracts.Persistence;
using UserExperience.Application.Exceptions;

namespace UserExperience.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public CreateUserCommandHandler(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }



        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);


            if (!validationResult.IsValid)
            {
                throw new BadRequestException("Invlid User", validationResult);
            }

            var userToCreate = _mapper.Map<Domain.User>(request);
            await _userRepository.CreateAsync(userToCreate);

            return userToCreate.Id;

        }
    }
}
