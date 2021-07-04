using AspNetCore.Identity.MongoDbCore.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDbGenericRepository.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.Entities.Concrete
{

    [CollectionName("Personel")]
    public class Personel:  MongoIdentityUser
    {
        public Personel()
        {
            CreatedDate = DateTime.Now;
        }
        public string NameSurname { get; set; }
        public string Job { get; set; } 

        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    } 
}
