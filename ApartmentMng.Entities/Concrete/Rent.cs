using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.Entities.Concrete
{
    public class Rent : BaseModel
    {
        public string HousingId { get; set; }
        public DateTime RentDate { get; set; }
        public string RentalStatus { get; set; }

    }
}