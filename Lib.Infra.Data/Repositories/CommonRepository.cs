using Lib.Core.Contracts;
using Lib.Core.Entity;
using Lib.Infra.Sql;
using System;
using System.Text;

namespace Lib.Infra.Data.Repositories
{
    public class CommonRepository<T> : IRepository<T> where T : IBaseEntity
    {
        protected readonly LibContext context;

        public CommonRepository(LibContext context)
        {
            this.context = context;
        }
        public void Add(T entity)
        {
            context.Add(entity);
        }

        public void Dispose()
        {
            context.Dispose();
            GC.SuppressFinalize(this);
        }

        public int SaveChanges()
        {
           return context.SaveChangesAsync().Result;
        }

        public void Update(T entity)
        {
            context.Update(entity);
        }
    }
}
