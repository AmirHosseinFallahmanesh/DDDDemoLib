using FluentValidation;
using Lib.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Domain.Commands.Book.Validators
{
    public class DeleteBookCommandValidator: AbstractValidator<DeleteBookCommand>
    {
        private readonly IBookRepository bookRepository;

        public DeleteBookCommandValidator(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
            ValidateExists();
        }

        private void ValidateExists()
        {
            RuleFor(bookBaseCommand => bookBaseCommand.Id)
                .Must(id=>bookRepository.GetById(id)!=null)
                .WithSeverity(Severity.Error)
                .WithMessage("Book Not Exists");
               
        }
    }


}
