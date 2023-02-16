using FluentValidation;
using Lib.Application.AutoMapper;
using Lib.Core.Command;
using Lib.Core.Contracts;
using Lib.Domain.Commands.Book;
using Lib.Domain.Contracts;
using Lib.Domain.Events;

namespace Lib.Application.Book
{
    public class UpdateBookCommandHandler : CommandHandlerBase, ICommandHandler<UpdateBookCommand>
    {
        private readonly IBookRepository bookRepository;
        private readonly IValidator<UpdateBookCommand> bookCommandValidator;
        private readonly IEventPublisher<BookEvent> eventPublisher;

        public UpdateBookCommandHandler(IBookRepository bookRepository,
            IValidator<UpdateBookCommand> bookCommandValidator,
            IEventPublisher<BookEvent> eventPublisher)
        {
            this.bookRepository = bookRepository;
            this.bookCommandValidator = bookCommandValidator;
            this.eventPublisher = eventPublisher;
        }
        public Result Handle(UpdateBookCommand command)
        {
            var validationResult = Validate(command, bookCommandValidator);
            if (validationResult.IsValid)
            {
                var book = BookMapper.CommandToEntity(command);
                bookRepository.Update(book);
                bookRepository.SaveChanges();

                var newBook = bookRepository.GetById(book.Id);
                eventPublisher.Publish(BookMapper.EntityToEvent(newBook));
            }
            return Return();

        }
    }

}
