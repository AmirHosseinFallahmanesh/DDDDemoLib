using System;

namespace Lib.Domain.Commands.Publisher
{
    public class UpdatePublisherCommand : PublisherCommandBase
    {
        public Guid Id { get; set; }
    }

}
