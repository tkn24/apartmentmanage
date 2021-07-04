using ApartmentMng.Core.Models;
using ApartmentMng.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.Business.Abstract
{
    public interface IApartmentService
    {
        GetOneResult<Apartment> ApartmentAdd(Apartment apartment);

        GetManyResult<Apartment> GetAllApartments();
    }
}
