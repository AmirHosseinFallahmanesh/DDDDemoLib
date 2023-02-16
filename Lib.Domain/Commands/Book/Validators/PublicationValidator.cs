using FluentValidation;
using System;

namespace Lib.Domain.Commands.Book.Validators
{
    public class PublicationValidator: AbstractValidator<PublicationCommand>
    {
        public PublicationValidator()
        {
            validateEdition();
            validateYear();
        }

        private void validateEdition()
        {
            RuleFor(pub=>pub.Edition)
               .Must(edition => edition>0)
               .WithSeverity(Severity.Error)
               .WithMessage("edition must be higher than 0");
        }

        private void validateYear()
        {
            RuleFor(pub => pub.Year)
               .Must(year => year <= DateTime.Today.Year)
               .WithSeverity(Severity.Error)
               .WithMessage("publication year must be higher than current year");
        }

    }
}
