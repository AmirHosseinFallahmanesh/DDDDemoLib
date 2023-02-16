using Lib.Domain.Contracts;

namespace Lib.Domain.Commands.Publisher.Validators
{
    public class CreatePublisherCommandValidator : PublisherCommandValidatorBase<CreatePublisherCommand>
    {
        public CreatePublisherCommandValidator(IPublisherRepository publisherRepository)
            : base(publisherRepository)
        {
        }
    }

}
