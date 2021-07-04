using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.Entities.Concrete
{
    public class Dues:BaseModel
    {
        public string HousingId { get; set; }
        public DateTime DuesDate { get; set; }
        public string DuesStatus { get; set; }
    }
}
