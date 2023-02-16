using FluentValidation;
using Lib.Core.Command;
using Lib.Core.Contracts;
using Lib.Domain.Commands.Book;
using Lib.Domain.Contracts;
using Lib.Domain.Events;

namespace Lib.Application.Book
{
    public class DeleteBookCommandHandler : CommandHandlerBase, ICommandHandler<DeleteBookCommand>
    {
        private readonly IBookRepository bookRepository;
        private readonly IValidator<DeleteBookCommand> bookCommandValidator;
        private readonly IEventPublisher<DeleteBookEvent> eventPublisher;

        public DeleteBookCommandHandler(IBookRepository bookRepository,
            IValidator<DeleteBookCommand> bookCommandValidator,
            IEventPublisher<DeleteBookEvent> eventPublisher)
        {
            this.bookRepository = bookRepository;
            this.bookCommandValidator = bookCommandValidator;
            this.eventPublisher = eventPublisher;
        }
        public Result Handle(DeleteBookCommand command)
        {
            var validationResult = Validate(command, bookCommandValidator);
            if (validationResult.IsValid)
            {
                bookRepository.Delete(command.Id);
                bookRepository.SaveChanges();

             
                eventPublisher.Publish(new DeleteBookEvent { Id=command.Id});
            }
            return Return();

        }
    }

}
