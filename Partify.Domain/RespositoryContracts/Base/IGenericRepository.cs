using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Partify.Domain.RespositoryContracts.Base
{
    public interface IGenericRepository<T>
    {
        Task<T> GetFirstOrDefault(Expression<Func<T, bool>> predicate,string? includeProperties=null,bool tracked=true);
        Task<T> GetById(int id);
        Task<IList<T>> GetAll(Expression<Func<T, bool>>? predicate = null, string? includeProperties = null);
        Task Add(T entity);
        Task Delete(T entity);
    }

}
