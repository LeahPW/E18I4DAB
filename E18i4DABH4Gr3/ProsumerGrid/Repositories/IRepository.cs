using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace E18iDABH4Gr3.Repositories
{
    public interface IRepository<T>
    {
        Task<bool> Create(T t);
        Task<T> Read(string id);
        Task<bool> Update(string id, T t);
        Task<bool> Delete(string id);
        IOrderedQueryable<T> Query();
    }
}