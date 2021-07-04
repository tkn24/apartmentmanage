using ApartmentMng.Core.Models;
using ApartmentMng.Core.Repository.Abstract;
using ApartmentMng.Core.Settings;
using ApartmentMng.DataAccess.Context;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ApartmentMng.DataAccess.Repository
{
    public class MongoRepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {

        private readonly MongoDbContext _context;
        private readonly IMongoCollection<TEntity> _collection;

        public MongoRepositoryBase(IOptions<MongoSettings> settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<TEntity>();
        }

        public GetManyResult<TEntity> GetAll()
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var data = _collection.AsQueryable().ToList();
                if (data != null)
                    result.Result = data;
            }
            catch (Exception ex)
            {

                result.Message = "GetAll " + ex.Message;
                result.Success = false;
                result.Result = null;
            }
            return result;

        }

        public GetOneResult<TEntity> DeleteById(string id)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = _collection.FindOneAndDelete(filter);
                if (data != null)
                    result.Entity = data;
            }
            catch (Exception ex)
            {

                result.Message = "DeleteById " + ex.Message;
                result.Success = false;
                result.Entity = null;
            }
            return result;

        }

        public void DeleteMany(Expression<Func<TEntity, bool>> filter)
        {
            _collection.DeleteMany(filter);

        }

        public GetOneResult<TEntity> DeleteOne(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var deleteData = _collection.FindOneAndDelete(filter);
                result.Entity = deleteData;
            }
            catch (Exception ex)
            {

                result.Message = "DeleteOne " + ex.Message;
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }

        public GetManyResult<TEntity> FilterBy(Expression<Func<TEntity, bool>> filter)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                var data = _collection.Find(filter).ToList();
                if (data != null)
                    result.Result = data;
            }
            catch (Exception ex)
            {

                result.Message = "FilterBy " + ex.Message;
                result.Success = false;
                result.Result = null;
            }
            return result;
        }

        public GetOneResult<TEntity> GetById(string id)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                var objectId = ObjectId.Parse(id);
                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data =  _collection.Find(filter).FirstOrDefault();
                if (data != null)
                result.Entity = data;
            }
            catch (Exception ex)
            {

                result.Message = "GetById " + ex.Message;
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }

        public GetManyResult<TEntity> InsertMany(ICollection<TEntity> entities)
        {
            var result = new GetManyResult<TEntity>();
            try
            {
                _collection.InsertMany(entities);
                result.Result = entities;

            }
            catch (Exception ex)
            {

                result.Message = "InsertMany " + ex.Message;
                result.Success = false;
                result.Result = null;
            }
            return result;
        }

        public GetOneResult<TEntity> InsertOne(TEntity entity)
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                _collection.InsertOne(entity);
                result.Entity = entity;
                
            }
            catch (Exception ex)
            {

                result.Message = "InsertOne " + ex.Message;
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }

        public GetOneResult<TEntity> ReplaceOne(TEntity entity, string id,string type="object")
        {
            var result = new GetOneResult<TEntity>();
            try
            {
                object objectId = null;
                if (type == "guid")
                    objectId = Guid.Parse(id);
                else
                    objectId = ObjectId.Parse(id);

                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var updatedData = _collection.ReplaceOne(filter, entity);
                result.Entity = entity;
            }
            catch (Exception ex) 
            {

                result.Message = "ReplaceOne " + ex.Message;
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }

        public async Task<GetOneResult<TEntity>> GetByIdAsync(string id, string type="object")
        {

            var result = new GetOneResult<TEntity>();
            try
            {
                object objectId = null;
                if (type == "guid")
                    objectId = Guid.Parse(id);
                else
                    objectId = ObjectId.Parse(id);

                var filter = Builders<TEntity>.Filter.Eq("_id", objectId);
                var data = await _collection.Find(filter).FirstOrDefaultAsync();
                if (data != null)
                    result.Entity = data;
            }
            catch (Exception ex)
            {
                result.Message = $"GetById {ex.Message}";
                result.Success = false;
                result.Entity = null;
            }
            return result;
        }

     
    }
}
