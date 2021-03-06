﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CoisadiMae.Models;
using Xamarin.Forms;


namespace CoisadiMae.Infrastructure.Repositories
{
    /// <summary>
    /// Base repository.
    /// </summary>
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {

        readonly object _lock = new object();
        // readonly ICryptoFunctions _cryptoFunctions;
        readonly ILiteDBOperations _litedb;
        

        public BaseRepository()
        {
            //if (_litedb == null)
            //{
            //    _litedb = DBContext.Instance;
            //    CreateTables();
            //}
            _litedb = DependencyService.Get<ILiteDBOperations>();
        }

        //private void CreateTables()
        //{
        //    try
        //    {
        //        _litedb.CreateTable<Bot>();
        //        _litedb.CreateTable<Context>();
        //        _litedb.CreateTable<Simulation>();
        //        _litedb.CreateTable<Mom>();
                
                
        //        _litedb.CreateTable<Son>();
                                
        //        _litedb.CreateTable<Conversation>();
        //        _litedb.CreateTable<Message>();

                

        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
      
        //}

        /// <summary>
        /// Add the specified TEntity.
        /// </summary>
        /// <returns>The add.</returns>
        /// <param name="TEntity">TE ntity.</param>
        public void Add(T TEntity)
        {
            try
            {
                _litedb.Insert(TEntity);
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
                _litedb.Delete(TEntity);
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
                return _litedb.GetById<T>(pkId);
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
                return _litedb.GetAll<T>();
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
                return _litedb.GetAllWithPredicate(predicate);
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
                return _litedb.Get<T>(predicate);
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
                _litedb.Update(TEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}