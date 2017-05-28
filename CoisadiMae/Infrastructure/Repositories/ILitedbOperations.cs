using CoisadiMae.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoisadiMae.Infrastructure.Repositories
{
    public interface ILiteDBOperations
    {
        T Get<T>() where T : class;

        T Get<T>(Expression<Func<T, bool>> predicat) where T : class;

        T GetById<T>(int id) where T : class;


        List<T> GetAll<T>() where T : class;
        List<T> GetAllWithPredicate<T>(Expression<Func<T, bool>> predicate) where T : class;

        void Update<T>(T entity) where T : class;
        void UpdateAll<T>(List<T> entities) where T : class;

        void Delete(BaseEntity entity);
        void DeleteAll(List<BaseEntity> entities);
        void DeleteAll(string entityName);

        void Insert<T>(T entity) where T : class;
        void InsertAll<T>(List<T> entities) where T : class;
    }
}
