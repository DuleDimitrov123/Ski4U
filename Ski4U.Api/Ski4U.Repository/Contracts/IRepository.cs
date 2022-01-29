using Ski4U.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ski4U.Repository.Contracts
{
    public interface IRepository<T> where T : class, IEntityWithId
    {
        Task<T> GetOne(int id);

        Task<T> Add(T obj);

        Task<T> Delete(T obj);

        Task<T> DeleteById(int id);

        Task<T> Update(T obj);

        Task<IList<T>> GetAll();

        Task<IList<T>> GetAllWithIncludes(params Expression<Func<T, Object>>[] includes);

        T GetOneWithIncludes(int id, params Expression<Func<T, object>>[] includes);
    }
}
