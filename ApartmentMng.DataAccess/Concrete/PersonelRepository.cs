using ApartmentMng.Core.Settings;
using ApartmentMng.DataAccess.Abstract;
using ApartmentMng.DataAccess.Context;
using ApartmentMng.DataAccess.Repository;
using ApartmentMng.Entities.Concrete;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ApartmentMng.DataAccess.Concrete
{
    public class PersonelRepository: MongoRepositoryBase<Personel>, IPersonelRepository
    {
        private readonly MongoDbContext _context;
        private readonly IMongoCollection<Personel> _collection;
        public PersonelRepository(IOptions<MongoSettings>settings):base(settings)
        {
            _context = new MongoDbContext(settings);
            _collection = _context.GetCollection<Personel>();
        }
    }
}
