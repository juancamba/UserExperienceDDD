using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UserExperience.Application.Contracts.Persistence;
using UserExperience.Application.Exceptions;

namespace UserExperience.Application.Features.Workingexperience.Commands.CreateWorkingexperience
{
    internal class CreateWorkingexperienceCommandHandler : IRequestHandler<CreateWorkingexperienceCommand, Unit>
    {
        private readonly IMapper _mapper;

        private readonly IWorkingexperienceRepository _workingexperienceRepository;
        private readonly IUserRepository _userRepository;

        public CreateWorkingexperienceCommandHandler(IMapper mapper, IWorkingexperienceRepository workingexperienceRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _workingexperienceRepository = workingexperienceRepository;
            _userRepository = userRepository;
        }


        public async Task<Unit> Handle(CreateWorkingexperienceCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateWorkingexperienceValidator(_userRepository);
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
                throw new BadRequestException("Invalid Leave Allocation Request", validationResult);

            var workingexperience = _mapper.Map<Domain.Workingexperience>(request);
            await _workingexperienceRepository.CreateAsync(workingexperience);
            return Unit.Value;
        }
    }
}
