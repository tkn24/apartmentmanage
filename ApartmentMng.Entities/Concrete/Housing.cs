using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.Entities.Concrete
{
    public class Housing : BaseModel
    {

        public string HousingNo { get; set; }
        public int RentMoney { get; set; }
        public string ApartmentName { get; set; }


        //Oturan kişi?
    }
}
