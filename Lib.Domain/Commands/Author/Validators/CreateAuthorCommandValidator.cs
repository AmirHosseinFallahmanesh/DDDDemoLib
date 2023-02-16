using Lib.Domain.Contracts;

namespace Lib.Domain.Commands.Author.Validators
{
    public class CreateAuthorCommandValidator : AuthorCommandValidatorBase<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator(IAuthorRepository authorRepository)
            : base((authorRepository))
        {
        }
    }
}
