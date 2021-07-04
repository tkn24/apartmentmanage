using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.Models.Request.Housing
{
    public class HousingAddModel
    {
        public string HousingNo { get; set; }
        public int RentMoney { get; set; }
        public string ApartmentName { get; set; }
    }
}
