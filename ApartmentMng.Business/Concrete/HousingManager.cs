using ApartmentMng.Business.Abstract;
using ApartmentMng.Core.Models;
using ApartmentMng.DataAccess.Abstract;
using ApartmentMng.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.Business.Concrete
{
    public class HousingManager : IHousingService
    {
        private readonly IHousingRepository _housingRepository;
        public HousingManager(IHousingRepository housingRepository)
        {
            _housingRepository = housingRepository;
        }

        public GetManyResult<Housing> GetAllHousings()
        {
            var housingList = _housingRepository.GetAll();
            return housingList;
        }

        public GetOneResult<Housing> HousingAdd(Housing housing)
        {
            var housingAdd = _housingRepository.InsertOne(housing);
            return housingAdd;
        }
    }
}
