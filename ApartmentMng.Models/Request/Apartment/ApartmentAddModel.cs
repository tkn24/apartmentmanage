using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.Models.Request.Apartment
{
    public class ApartmentAddModel
    {
        
        public string ApartmentName { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Address { get; set; }
        public string ApartmentManager { get; set; }
    }
}
