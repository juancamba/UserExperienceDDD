using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserExperience.Application.Features.User.Commands.CreateUser;
using UserExperience.Application.Features.User.Queries.GetAllUsers;

namespace UserExperience.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Get()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);

        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<int>> Post(CreateUserCommand createUserCommand)
        {
            var id = await _mediator.Send(createUserCommand);
            return Ok(id);
        }
    }
}
