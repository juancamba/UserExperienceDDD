using AutoMapper;
using MediatR;
using UserExperience.Application.Contracts.Logging;
using UserExperience.Application.Contracts.Persistence;
using UserExperience.Application.Exceptions;

namespace UserExperience.Application.Features.Workingexperience.Queries.GetWorkingexperience
{
    public class GetWorkingexperienceQueryHandler : IRequestHandler<GetWorkingexperienceQuery, List<WorkingexperienceDto>>
    {

        private readonly IMapper _mapper;
        private readonly IWorkingexperienceRepository _workingexperienceRepository;
        private readonly IAppLogger<GetWorkingexperienceQueryHandler> _logger;


        public GetWorkingexperienceQueryHandler(IMapper mapper, IWorkingexperienceRepository workingexperienceRepository, IAppLogger<GetWorkingexperienceQueryHandler> logger)
        {
            _mapper = mapper;
            _workingexperienceRepository = workingexperienceRepository;
            _logger = logger;
        }


        public async Task<List<WorkingexperienceDto>> Handle(GetWorkingexperienceQuery request, CancellationToken cancellationToken)
        {
            var workingexperiences = (await _workingexperienceRepository.GetWorkingexperiencesByUserId(request.userId)).OrderBy(x => x.StartDate);

            if (workingexperiences == null)
            {

                _logger.LogWarning("No working experiences found for user with id: {userId}", request.userId);
                throw new NotFoundException("No working experiences found for user with id: {userId}", request.userId);
            }

            return _mapper.Map<List<WorkingexperienceDto>>(workingexperiences);
        }
    }

}
