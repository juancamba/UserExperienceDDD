using FluentValidation.Results;

namespace UserExperience.Application.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string message) : base(message)
        {
        }
        public BadRequestException(string message, ValidationResult validationResult) : base(message)
        {
            ValidationErrors = validationResult.ToDictionary();
            /*
            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }*/
        }
        public IDictionary<string, string[]> ValidationErrors { get; set; }
    }
}
