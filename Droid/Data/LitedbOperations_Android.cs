using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using LiteDB;
using System.Linq.Expressions;
using CoisadiMae.Models;
using CoisadiMae.Droid.Data;
using Xamarin.Forms;
using CoisadiMae.Infrastructure.Repositories;

[assembly: Dependency(typeof(LitedbOperations_Android))]
namespace CoisadiMae.Droid.Data
{
 public   class LitedbOperations_Android : ILiteDBOperations
    {
        LiteDatabase db;
        readonly BsonMapper mapper;
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        string _connection { get; set; }

        public LitedbOperations_Android()
        {
           
            _connection = $"Filename={folder}/MyData.db";
        }

        LiteCollection<T> GetCollection<T>()
        {
            return db.GetCollection<T>();
        }

        public T Get<T>() where T : class
        {
            using (db = GetDatabase())
            {
                var collection = GetCollection<T>();
                return collection.FindAll().FirstOrDefault() as T;
            }
        }


        public T GetById<T>(int id) where T : class
        {
            using (db = GetDatabase())
            {
                var collection = GetCollection<T>();
                return collection.FindById(id);
            }
        }

        public List<T> GetAll<T>() where T : class
        {
            using (db = GetDatabase())
            {
                var collection = GetCollection<T>();
                var all = collection.FindAll().ToList();
                return all;
            }
        }

        public List<T> GetAllWithPredicate<T>(Expression<Func<T, bool>> predicate) where T : class
        {
            using (db = GetDatabase())
            {
                var collection = GetCollection<T>();
                var list = collection.FindAll();
                return list.AsQueryable().Where(predicate).ToList();
            }
        }

        public void Update<T>(T entity) where T : class
        {
            using (db = GetDatabase())
            {
                var collection = GetCollection<T>();
                collection.Update(entity);
            }
        }

        public void UpdateAll<T>(List<T> entities) where T : class
        {
            using (db = GetDatabase())
            {
                var collection = GetCollection<T>();
                collection.Update(entities);
            }
        }

        public void Delete(BaseEntity entity)
        {
            using (db = GetDatabase())
            {
                var collection = db.GetCollection(entity.GetType().Name);
                var query = Query.Contains("Id", entity.Id.ToString());
                collection.Delete(query);
            }
        }

        public void DeleteAll(List<BaseEntity> entities)
        {
            entities.ForEach(Delete);
        }

        public void DeleteAll(string entityName)
        {
            using (db = GetDatabase())
            {
                var collection = db.GetCollection(entityName);
                var query = Query.All();
                collection.Delete(query);
            }
        }

        public void Insert<T>(T entity) where T : class
        {
            using (db = GetDatabase())
            {
                var collection = GetCollection<T>();
                collection.Upsert(entity);
            }
        }

        public void InsertAll<T>(List<T> entities) where T : class
        {
            using (db = GetDatabase())
            {
                var collection = GetCollection<T>();
                collection.Upsert(entities);
            }
        }

        private LiteDatabase GetDatabase()
        {
            try
            {
                var database = new LiteDatabase(_connection);
                // verify if engine is ok
                var userVersion = database.Engine.UserVersion;

                return database;
            }
            catch (LiteException lex)
            {
                if (lex.ErrorCode == LiteException.DATABASE_WRONG_PASSWORD)
                {
                    System.IO.File.Delete($"{folder}/MyData.db");
                    return new LiteDatabase(_connection);
                }
                else
                {
                    return null;
                }
            }
        }

        public T Get<T>(Expression<Func<T, bool>> predicat) where T : class
        {
            using (db = GetDatabase())
            {
                var collection = GetCollection<T>();
                var list = collection.FindAll();
                return list.AsQueryable().Where(predicat).FirstOrDefault();
            }
        }

   
    }
}