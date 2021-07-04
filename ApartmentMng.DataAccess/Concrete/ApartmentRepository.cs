using ApartmentMng.Core.Settings;
using ApartmentMng.DataAccess.Abstract;
using ApartmentMng.DataAccess.Context;
using ApartmentMng.DataAccess.Repository;
using ApartmentMng.Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.DataAccess.Concrete
{
    public class ApartmentRepository : MongoRepositoryBase<Apartment>, IApartmentRepository
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<Apartment> _collection;
        public ApartmentRepository(IOptions<MongoSettings> settings) : base(settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<Apartment>();
        }
    }
}
