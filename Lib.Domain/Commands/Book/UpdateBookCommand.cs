using System;

namespace Lib.Domain.Commands.Book
{
    public class UpdateBookCommand:BookCommandBase
    {
        public Guid Id { get; set; }
 
    }
}
