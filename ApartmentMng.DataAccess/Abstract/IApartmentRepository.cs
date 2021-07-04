using ApartmentMng.Core.Repository.Abstract;
using ApartmentMng.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.DataAccess.Abstract
{
    public interface IApartmentRepository : IRepository<Apartment>
    {
    }
}
