using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoisadiMae.ApplicationServices
{
    public interface IApplicationService<T>
    {
        void Add(T TEntity);
        void Delete(T TEntity);
        void Update(T TEntity);

        Task AddAsync(T TEntity);
        Task DeleteAsync(T TEntity);
        Task UpdateAsync(T TEntity);

        T Get(int pkId);
        T GetWithPredicate(Expression<Func<T, bool>> predicate);

        Task<T> GetAsync(int pkId);
        Task<T> GetWithPredicateAsync(Expression<Func<T, bool>> predicate);

        List<T> GetAll();
        List<T> GetAllWithPredicate(Expression<Func<T, bool>> predicate);

        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllWithPredicateAsync(Expression<Func<T, bool>> predicate);
    }
}