using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SQLiteNetExtensions.Extensions;
using CoisadiMae.Infrastructure.Configurations;
using CoisadiMae.Models;

namespace CoisadiMae.Infrastructure.Repositories
{
    /// <summary>
    /// Base repository.
    /// </summary>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        public BaseRepository()
        {
            if (App.AppConn == null)
                App.AppConn = DBContext.Instance;
        }

        /// <summary>
        /// Add the specified TEntity.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Add(T TEntity)
        {
            try
            {
                App.AppConn.InsertOrReplaceWithChildren(TEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete the specified TEntity.
        /// </summary>
        /// <returns>The delete.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Delete(T TEntity)
        {
            try
            {
                App.AppConn.Delete(TEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get the specified pkId.
        /// </summary>
        /// <returns>The get.</returns>
        /// <param name="pkId">Pk identifier.</param>
        public T Get(int pkId)
        {
            try
            {
                return App.AppConn.GetWithChildren<T>(pkId, recursive: true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>The all.</returns>
        public List<T> GetAll()
        {
            try
            {
                return App.AppConn.GetAllWithChildren<T>();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets all with predicate.
        /// </summary>
        /// <returns>The all with predicate.</returns>
        /// <param name="predicate">Predicate.</param>
        public List<T> GetAllWithPredicate(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return App.AppConn.GetAllWithChildren(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the with predicate.
        /// </summary>
        /// <returns>The with predicate.</returns>
        /// <param name="predicate">Predicate.</param>
        public T GetWithPredicate(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return App.AppConn.GetWithChildren<T>(predicate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update the specified TEntity.
        /// </summary>
        /// <returns>The update.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Update(T TEntity)
        {
            try
            {
                App.AppConn.UpdateWithChildren(TEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}