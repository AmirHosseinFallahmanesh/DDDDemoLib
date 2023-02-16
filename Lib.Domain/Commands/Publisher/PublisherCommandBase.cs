using Lib.Core.Command;
using System.Collections.Generic;
using System.Text;

namespace Lib.Domain.Commands.Publisher
{
    public abstract class PublisherCommandBase : CommandBase
    {
        public string Name { get; set; }
    }

}
