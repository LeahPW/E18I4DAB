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
        Task Create(T t);
        Task<T> Read(int id);
        Task Update(int id, T t);
        Task<IEnumerable<T>> ReadAll();
        Task Delete(T t);
    }
}