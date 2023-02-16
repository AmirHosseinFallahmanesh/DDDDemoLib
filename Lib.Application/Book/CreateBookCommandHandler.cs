using FluentValidation;
using Lib.Application.AutoMapper;
using Lib.Core.Command;
using Lib.Core.Contracts;
using Lib.Domain.Commands.Book;
using Lib.Domain.Contracts;
using Lib.Domain.Events;


namespace Lib.Application.Book
{
    public class CreateBookCommandHandler : CommandHandlerBase, ICommandHandler<CreateBookCommand>
    {
        private readonly IBookRepository bookRepository;
        private readonly IValidator<CreateBookCommand> bookCreateCommandValidator;
        private readonly IEventPublisher<BookEvent> eventPublisher;

        public CreateBookCommandHandler(IBookRepository bookRepository,
            IValidator<CreateBookCommand>  bookCommandValidator,
            IEventPublisher<BookEvent> eventPublisher)
        {
            this.bookRepository = bookRepository;
            this.bookCreateCommandValidator = bookCommandValidator;
            this.eventPublisher = eventPublisher;
        }
        public Result Handle(CreateBookCommand command)
        {
            var validationResult = Validate(command, bookCreateCommandValidator);
            if (validationResult.IsValid)
            {
                var book = BookMapper.CommandToEntity(command);
                bookRepository.Add(book);
                bookRepository.SaveChanges();

                var newBook = bookRepository.GetById(book.Id);
                eventPublisher.Publish(BookMapper.EntityToEvent(newBook));
            }
            return Return();

        }
    }



}
