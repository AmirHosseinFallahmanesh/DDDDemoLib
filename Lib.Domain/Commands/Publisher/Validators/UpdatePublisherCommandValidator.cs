using FluentValidation;
using Lib.Domain.Contracts;
using System;

namespace Lib.Domain.Commands.Publisher.Validators
{
    public class UpdatePublisherCommandValidator : PublisherCommandValidatorBase<UpdatePublisherCommand>
    {
        public UpdatePublisherCommandValidator(IPublisherRepository publisherRepository)
            : base(publisherRepository)
        {
            ValidateId();
        }

        private void ValidateId()
        {
            RuleFor(updatePublisherCommand => updatePublisherCommand.Id)
                .Must(id => !id.Equals(Guid.Empty))
                .WithSeverity(Severity.Error)
                .WithMessage("Id can't be empty");
        }
    }

}
