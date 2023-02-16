using FluentValidation;
using Lib.Domain.Contracts;
using System.Collections.Generic;
using System.Text;

namespace Lib.Domain.Commands.Author.Validators
{
    public abstract class AuthorCommandValidatorBase<T> : AbstractValidator<T> where T : AuthorCommandBase
    {
        private readonly IAuthorRepository authorRepository;

        public AuthorCommandValidatorBase(IAuthorRepository authorRepository)
        {
            validateUniqueNameOnCreate();
            validateName();
            this.authorRepository = authorRepository;
        }

        private void validateName()
        {
            RuleFor(a => a.Name)
           .Must(title => !string.IsNullOrWhiteSpace(title))
           .WithSeverity(Severity.Error)
           .WithMessage("name cant be empty");
        }

        private void validateUniqueNameOnCreate()
        {
            RuleFor(a => a.Name)
                .MustAsync(async (name, cancellationToken) => !(await authorRepository.ExistsAsync(name)))
                .WithSeverity(Severity.Error)
                .WithMessage("name already exists!");
        }
    }
}
