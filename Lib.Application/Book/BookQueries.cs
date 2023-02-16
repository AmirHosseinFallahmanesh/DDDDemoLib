using Lib.Domain.Contracts;
using Lib.Domain.Events;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.Application.Book
{
    public class BookQueries : IBookQuery
    {
        private readonly IBookEventRepository bookEventRepository;

        public BookQueries(IBookEventRepository bookEventRepository)
        {
            this.bookEventRepository = bookEventRepository;
        }
        public async Task<IEnumerable<BookEvent>> GetAllAsync()
        {
            return await bookEventRepository.GetAllAsync();
        }

        public async Task<IEnumerable<BookEvent>> GetTextAsync(string text)
        {
            return await bookEventRepository.GetByTextAsync(text);
        }
    }

    public interface IBookQuery
    {
        Task<IEnumerable<BookEvent>> GetAllAsync();
        Task<IEnumerable<BookEvent>> GetTextAsync(string text);
    }


}
