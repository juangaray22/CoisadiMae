using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CoisadiMae.Infrastructure.Repositories;
using CoisadiMae.Models;

namespace CoisadiMae.ApplicationServices
{
    /// <summary>
    /// Application services.
    /// </summary>
    public class ApplicationService<T> : IApplicationService<T> where T : BaseEntity
    {
        readonly IBaseRepository<T> _repository;

        public ApplicationService(IBaseRepository<T> repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Add the specified TEntity.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Add(T TEntity)
        {
            this._repository.Add(TEntity);
        }

        /// <summary>
        /// Adds the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public async Task AddAsync(T TEntity)
        {
            await Task.Run(() => this._repository.Add(TEntity));
        }

        /// <summary>
        /// Delete the specified TEntity.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Delete(T TEntity)
        {
            this._repository.Delete(TEntity);
        }

        /// <summary>
        /// Deletes the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public async Task DeleteAsync(T TEntity)
        {
            await Task.Run(() => this._repository.Delete(TEntity));
        }

        /// <summary>
        /// Get the specified pkId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="pkId">Pk identifier.</param>
        public T Get(int pkId)
        {
            return this._repository.Get(pkId);
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The all.</returns>
        public List<T> GetAll()
        {
            return this._repository.GetAll();
        }

        /// <summary>
        /// Gets all async.
        /// </summary>
        /// <returns>The all async.</returns>
        public async Task<List<T>> GetAllAsync()
        {
            return await Task.Run(() => this._repository.GetAll());
        }

        /// <summary>
        /// Gets all with predicate.
        /// </summary>
        /// <returns>The all with predicate.</returns>
        /// <param name="predicate">Predicate.</param>
        public List<T> GetAllWithPredicate(Expression<Func<T, bool>> predicate)
        {
            return this._repository.GetAllWithPredicate(predicate);
        }

        /// <summary>
        /// Gets all with predicate async.
        /// </summary>
        /// <returns>The all with predicate async.</returns>
        /// <param name="predicate">Predicate.</param>
        public async Task<List<T>> GetAllWithPredicateAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => this._repository.GetAllWithPredicate(predicate));
        }

        /// <summary>
        /// Gets the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="pkId">Pk identifier.</param>
        public async Task<T> GetAsync(int pkId)
        {
            return await Task.Run(() => this._repository.Get(pkId));
        }

        /// <summary>
        /// Gets the with predicate.
        /// </summary>
        /// <returns>The with predicate.</returns>
        /// <param name="predicate">Predicate.</param>
        public T GetWithPredicate(Expression<Func<T, bool>> predicate)
        {
            return this._repository.GetWithPredicate(predicate);
        }

        /// <summary>
        /// Gets the with predicate async.
        /// </summary>
        /// <returns>The with predicate async.</returns>
        /// <param name="predicate">Predicate.</param>
        public async Task<T> GetWithPredicateAsync(Expression<Func<T, bool>> predicate)
        {
            return await Task.Run(() => this._repository.GetWithPredicate(predicate));
        }

        /// <summary>
        /// Update the specified TEntity.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Update(T TEntity)
        {
            this._repository.Update(TEntity);
        }

        /// <summary>
        /// Updates the async.
        /// </summary>
        /// <returns>The async.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public async Task UpdateAsync(T TEntity)
        {
            await Task.Run(() => this._repository.Update(TEntity));
        }
    }
}