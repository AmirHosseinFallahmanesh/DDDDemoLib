using Lib.Core.Entity;
using System;
using System.Text;

namespace Lib.Core.Contracts
{
    public interface IRepository<in T> : IDisposable where T : IBaseEntity
    {
        void Add(T entity);
        void Update(T entity);
        int SaveChanges();
    }
}

