using FluentValidation;
using Lib.Domain.Contracts;

namespace Lib.Domain.Commands.Book.Validators
{
    public class CreateBookCommandValidator : BookCommandValidatorBase<CreateBookCommand>
    {
        public CreateBookCommandValidator(IBookRepository bookRepository,
            IValidator<PublicationCommand> publicationValidator)
            : base(bookRepository, publicationValidator)
        {
           ValidateNameOnCreate();
        }


    }
}
