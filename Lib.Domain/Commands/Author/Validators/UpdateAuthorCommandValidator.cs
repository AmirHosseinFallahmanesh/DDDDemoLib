using FluentValidation;
using Lib.Domain.Contracts;
using System;

namespace Lib.Domain.Commands.Author.Validators
{
    public class UpdateAuthorCommandValidator : AuthorCommandValidatorBase<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator(IAuthorRepository authorRepository)
            : base(authorRepository)
        {
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(updateAuthorCommand => updateAuthorCommand.Id)
                .Must(id => !id.Equals(Guid.Empty))
                .WithSeverity(Severity.Error)
                .WithMessage("Id can't be empty");
        }
    }
}
