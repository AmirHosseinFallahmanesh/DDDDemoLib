namespace Lib.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController: ControllerBase
    {

        private readonly ICommandHandler<CreateBookCommand> _createBookCommandHandler;
        private readonly ICommandHandler<UpdateBookCommand> _updateBookCommandHandler;
        private readonly ICommandHandler<DeleteBookCommand> _deleteBookCommandHandler;
        private readonly IBookQueries _bookQueries;

        public BookController(ICommandHandler<CreateBookCommand> createBookCommandHandler,
            ICommandHandler<UpdateBookCommand> updateBookCommandHandler,
            ICommandHandler<DeleteBookCommand> deleteBookCommandHandler,
            IBookQueries bookQueries)
        {
            _createBookCommandHandler = createBookCommandHandler;
            _updateBookCommandHandler = updateBookCommandHandler;
            _deleteBookCommandHandler = deleteBookCommandHandler;
            _bookQueries = bookQueries;
        }

        [HttpGet]
        [Route("{text}")]
        public async Task<IActionResult> Get(string text)
        {
            return Ok(await _bookQueries.GetByTextAsync(text));
        }


        [HttpPost]
       
        public  IActionResult Post(CreateBookCommand command)
        {
            var result = _createBookCommandHandler.Handle(command);
            if (result.Sucess)
                    return Ok(command);
            return BadResquest(result.Errors);
        }

        [HttpPut]

        public  IActionResulr Put(UpdateBookCommand command)
        {
            var result = _updateBookCommandHandler.Handle(command);
            if (result.Sucess)
                return Ok(command);
            return BadResquest(result.Errors);
        }
    }
}
