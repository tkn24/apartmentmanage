using ApartmentMng.Business.Abstract;
using ApartmentMng.Core.Models;
using ApartmentMng.DataAccess.Abstract;
using ApartmentMng.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApartmentMng.Business.Concrete
{
    public class ApartmentManager : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        public ApartmentManager(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
           
        }

      
        public GetOneResult<Apartment> ApartmentAdd(Apartment apartment)
        {
            var apartmentAdd = _apartmentRepository.InsertOne(apartment);
            return apartmentAdd;
        }

        public GetManyResult<Apartment> GetAllApartments()
        {
            var apartmentList = _apartmentRepository.GetAll();
            return apartmentList;
        }
    }
}
