using FluentValidation;
using UserExperience.Application.Contracts.Persistence;

namespace UserExperience.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        private readonly IUserRepository _userRepository;



        public CreateUserCommandValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;


            RuleFor(p => p.UserName)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(q => q)
            .MustAsync(UserNameUnique)
            .WithMessage("A user with the same username already exists.");


            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Web)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
            RuleFor(p => p.Direccion)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
        }

        private async Task<bool> UserNameUnique(CreateUserCommand createUserCommand, CancellationToken arg2)
        {
            return await _userRepository.IsUserNameUnique(createUserCommand.UserName);
        }
    }


}
