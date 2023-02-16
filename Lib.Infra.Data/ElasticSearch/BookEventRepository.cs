using Lib.Domain.Contracts;
using Lib.Domain.Events;
using Lib.Infra.ElasticSearch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.Infra.Data.ElasticSearch
{
    public class BookEventRepository: BaseElasticSearchRepository<BookEvent,Guid>,IBookEventRepository
    {

        public BookEventRepository(IElasticContextProvider context):base(context,"book")
        {
           
        }

        public async Task<IEnumerable<BookEvent>> GetByTextAsync(string text)
        {
            var response = await context.GetClient()
                .SearchAsync<BookEvent>(s => s.Index(index)
                .Query(q => q.MultiMatch
                (m => m.Fields(opt => opt.Field(f => f.Title)
                .Field(f => f.AuthorCreateEvent.Name)
                .Field(f => f.PublisherCreateEvent.Name))
                .Query(text))));

            return response.Documents;
                
               
        }
    }
}
