using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;

namespace Lib.Core.Command
{
    public abstract class CommandHandlerBase
    {
        protected List<string> Notifications;

        protected ValidationResult Validate<T, TValidator>(
               T command,
               TValidator validator)
               where T : CommandBase
               where TValidator : IValidator<T>
        {
            var validationResult = validator.Validate(command);
            Notifications = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

            return validationResult;
        }
        public Result Return() => new Result(!Notifications.Any(), Notifications); 
    }
}
