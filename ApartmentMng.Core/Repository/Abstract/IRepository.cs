using ApartmentMng.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentMng.Core.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        GetManyResult<TEntity> GetAll();

        GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter);

        GetOneResult<TEntity> GetById(string id);

        Task<GetOneResult<TEntity>> GetByIdAsync(string id, string type="object");

        GetOneResult<TEntity> InsertOne(TEntity entity);

        GetManyResult<TEntity> InsertMany(ICollection<TEntity> entities);

        GetOneResult<TEntity> ReplaceOne(TEntity entity, string id, string type = "object");
        GetOneResult<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter);

        GetOneResult<TEntity> DeleteById(string id);

        void DeleteMany(Expression<Func<TEntity, bool>> filter);






    }
}
