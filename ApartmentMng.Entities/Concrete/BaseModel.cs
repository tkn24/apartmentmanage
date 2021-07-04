using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.Entities.Concrete
{
    public class BaseModel
    {
        [BsonId] // Primary Key
        public ObjectId Id { get; set; }
    }
}
