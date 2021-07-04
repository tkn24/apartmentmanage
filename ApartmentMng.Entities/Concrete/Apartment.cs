using MongoDbGenericRepository.Attributes;

namespace ApartmentMng.Entities.Concrete
{
    [CollectionName("Apartment")]
    public class Apartment:BaseModel
    {

        public string ApartmentName { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Address { get; set; }
        public string ApartmentManager { get; set; }
        //public string ApartmentOwner { get; set; }
        //public string[] Homes { get; set; }
    }
}
