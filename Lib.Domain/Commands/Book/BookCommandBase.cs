using Lib.Core.Command;
using System;

namespace Lib.Domain.Commands.Book
{
    public class BookCommandBase: CommandBase
    {
        public string Title { get; set; }
        public Guid PublisherId { get; set; }
        public Guid AutorId { get; set; }

        public PublicationCommand Publication { get; set; }
    }
}
