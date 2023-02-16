using System;
using FluentValidation;
using Lib.Domain.Contracts;

namespace Lib.Domain.Commands.Book.Validators
{
    public class UpdateBookCommandValidator : BookCommandValidatorBase<UpdateBookCommand>
    {
        public UpdateBookCommandValidator(IBookRepository bookRepository,
            IValidator<PublicationCommand> publicationValidator)
            : base(bookRepository, publicationValidator)
        {
            ValidateId();
        }

        private void ValidateId()
        {
           RuleFor(book=>book.Id)
                .Must(id=>!id.Equals(Guid.Empty))
                .WithSeverity(Severity.Error)
                .WithMessage("Id can't be empty");
        }
    }
}
