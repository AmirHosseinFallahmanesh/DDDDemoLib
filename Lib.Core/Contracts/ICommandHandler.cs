using Lib.Core.Command;

namespace Lib.Core.Contracts
{
    public interface ICommandHandler<in T> where T : CommandBase
    {
        Result Handle(T Command);
    }

  
}
