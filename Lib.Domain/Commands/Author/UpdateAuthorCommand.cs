using System;

namespace Lib.Domain.Commands.Author
{
    public class UpdateAuthorCommand : AuthorCommandBase
    {
        public Guid Id { get; set; }
    }
}
