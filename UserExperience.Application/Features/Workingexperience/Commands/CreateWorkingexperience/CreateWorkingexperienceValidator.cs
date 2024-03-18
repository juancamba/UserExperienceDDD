using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserExperience.Application.Contracts.Persistence;

namespace UserExperience.Application.Features.Workingexperience.Commands.CreateWorkingexperience
{
    public class CreateWorkingexperienceValidator : AbstractValidator<CreateWorkingexperienceCommand>
    {
        private readonly IUserRepository _userRepository;

        public CreateWorkingexperienceValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            RuleFor(p => p.UserId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MustAsync(UserMustExists).WithMessage("The selected user doesn't exist.");
        }

        private async Task<bool> UserMustExists(int id, CancellationToken arg2)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return user != null;
        }
    }
}
