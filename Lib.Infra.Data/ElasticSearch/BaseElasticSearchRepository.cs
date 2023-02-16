using Elasticsearch.Net;
using Lib.Core.Contracts;
using Lib.Core.Event;
using Lib.Core.Message;
using Lib.Infra.ElasticSearch;
using Nest;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Infra.Data.ElasticSearch
{
    public abstract class BaseElasticSearchRepository<TDocument, TPrimaryKey>
         : IElasticSearchRepository<TDocument, TPrimaryKey>
         where TDocument : class, IMessage<TPrimaryKey>
         where TPrimaryKey : struct
    {
        protected readonly IElasticContextProvider context;
        protected readonly string index;

        public BaseElasticSearchRepository(IElasticContextProvider context,string index)
        {
            this.context = context;
            this.index = index;
        }

        private TDocument Index(TDocument entity)
        {
            var respnose=context.GetClient()
                .Index(entity,idx=>idx.Index(index)
                .Id(new Id(entity.Id.ToString()))
                .Refresh(Refresh.WaitFor));

            return entity;
        }

        private async Task<TDocument> IndexAsync(TDocument entity)
        {
            var respnose = await context.GetClient()
                .IndexAsync(entity, idx => idx.Index(index)
                 .Id(new Id(entity.Id.ToString()))
                 .Refresh(Refresh.WaitFor));

            return entity;
        }
        public TDocument Add(TDocument entity)
        {
            return Index(entity);
        }

        public async Task<TDocument> AddAsync(TDocument entity)
        {
           return await IndexAsync(entity);
        }

        public TDocument AddOrUpdate(TDocument entity)
        {
            return Index(entity);
        }

        public async Task<TDocument> AddOrUpdateAsync(TDocument entity)
        {
            return await IndexAsync(entity);
        }

        public async Task<IEnumerable<TDocument>> GetAllAsync()
        {
            var query = await context.GetClient()
                .SearchAsync<TDocument>(idx => idx.Index(index).Size(1000));
            return query.Documents;
        }

        public TDocument GetById(TPrimaryKey id)
        {
            var query =  context.GetClient()
                  .Search<TDocument>(idx => idx.Index(index).
                  Query(q=>q.Match(m=>m.Field(u=>u.Id).Query(id.ToString()))));
            return query.Documents.FirstOrDefault();
        }

        public async Task<TDocument> GetByIdAsync(TPrimaryKey id)
        {
            var query = await context.GetClient()
               .SearchAsync<TDocument>(idx => idx.Index(index).
               Query(q => q.Match(m => m.Field(u => u.Id).Query(id.ToString()))));
            return query.Documents.FirstOrDefault();
        }

        public void Remove(TDocument entity)
        {
            context.GetClient().DeleteByQuery<TDocument>(q => q.Index(index)
           .Query(p => p.Match(s => s.Field("_id").Query(entity.Id.ToString()))));
        }

        public async Task<TDocument> RemoveAsync(TDocument entity)
        {
             await context.GetClient().DeleteByQueryAsync<TDocument>(q => q.Index(index)
       .Query(p => p.Match(s => s.Field("_id").Query(entity.Id.ToString()))));
            return entity;
        }

        public async Task<TDocument> RemoveAsync(TPrimaryKey id)
        {
            var entity = await GetByIdAsync(id);
            return await RemoveAsync(entity);
        }
    }
}
