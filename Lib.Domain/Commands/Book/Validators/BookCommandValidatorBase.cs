using FluentValidation;
using Lib.Domain.Contracts;
using System;

namespace Lib.Domain.Commands.Book.Validators
{
    public class BookCommandValidatorBase<T>:AbstractValidator<T> where T : BookCommandBase
    {
        private readonly IBookRepository bookRepository;
        private readonly IValidator<PublicationCommand> publicatoinValidator;

        public BookCommandValidatorBase(IBookRepository bookRepository,IValidator<PublicationCommand> publicatoinValidator)
        {
            this.bookRepository = bookRepository;
            this.publicatoinValidator = publicatoinValidator;

            ValidateAuthor();
            ValidatePublification();
            ValidatePublisher();
            ValidateTitle();
        }

        protected void ValidateNameOnCreate()
        {
            RuleFor(a => a.Title)
                .MustAsync(async(title,cancellationToken)=>!(await bookRepository.ExistsAsync(title)))
                .WithSeverity(Severity.Error)
                .WithMessage("book already exists!");
        }

        private void ValidateTitle()
        {
            RuleFor(a => a.Title)
                .Must(title => !string.IsNullOrWhiteSpace(title))
                .WithSeverity(Severity.Error)
                .WithMessage("title cant be empty");
        }

        private void ValidateAuthor()
        {
           
            RuleFor(a => a.AutorId)
                .Must(id => !Guid.Empty.Equals(id))
                .WithSeverity(Severity.Error)
                .WithMessage("author cant be empty");
        }


        private void ValidatePublisher()
        {

            RuleFor(a => a.AutorId)
                .Must(id => !Guid.Empty.Equals(id))
                .WithSeverity(Severity.Error)
                .WithMessage("publisher cant be empty");
        }

        protected void ValidatePublification()
        {
            RuleFor(a => a.Publication)
           .Must(pub=>publicatoinValidator.Validate(pub).IsValid )
           .WithSeverity(Severity.Error)
           .WithMessage("publication not valid");
        }
    }
}
