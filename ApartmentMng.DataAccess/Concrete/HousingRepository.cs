using ApartmentMng.Core.Settings;
using ApartmentMng.DataAccess.Abstract;
using ApartmentMng.DataAccess.Context;
using ApartmentMng.DataAccess.Repository;
using ApartmentMng.Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApartmentMng.DataAccess.Concrete
{
    public class HousingRepository : MongoRepositoryBase<Housing>, IHousingRepository
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<Housing> _collection;

        public HousingRepository(IOptions<MongoSettings> settings) : base(settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<Housing>();
        }
    }
}
