using ApartmentMng.Core.Models;
using ApartmentMng.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.Business.Abstract
{
    public interface IHousingService
    {
        GetOneResult<Housing> HousingAdd(Housing housing);

        GetManyResult<Housing> GetAllHousings();
    }
}
