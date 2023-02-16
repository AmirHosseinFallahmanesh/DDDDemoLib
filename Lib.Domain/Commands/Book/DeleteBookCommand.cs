using System;

namespace Lib.Domain.Commands.Book
{
    public class DeleteBookCommand:BookCommandBase
    {
        public Guid Id { get; set; }
    }
}
