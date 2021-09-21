using CodingTest.CodingTest.Contracts.Entites;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CodingTest.CodingTest.Contracts
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>> predicate = null);
        Task<T> FindAsync(int id);
        Task<bool> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
    }
}
