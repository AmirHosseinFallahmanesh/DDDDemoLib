using Lib.Core.Command;
using System.Collections.Generic;
using System.Text;

namespace Lib.Domain.Commands.Author
{
    public  class AuthorCommandBase:CommandBase
    {
        public string Name { get; set; }
    }
}
