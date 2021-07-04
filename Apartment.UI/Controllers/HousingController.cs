using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApartmentMng.Business.Abstract;
using ApartmentMng.Models.Request.Housing;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentMng.UI.Controllers
{
    public class HousingController : Controller
    {

        private readonly IHousingService _housingService;  //dependency injection
        private readonly IApartmentService _apartmentService;

        public HousingController(IApartmentService apartmentService, IHousingService housingService)
        {
            _apartmentService = apartmentService;
            _housingService = housingService;
        }


        public IActionResult GetAllHousings()
        {
            if (ModelState.IsValid)
            {
                var result = _housingService.GetAllHousings();
                return View(result);
            }
            return NotFound("hata");
        }


        [HttpGet]
        public IActionResult HousingAdd()
        {
            var result = _apartmentService.GetAllApartments();
            return View(result);
        }

        [HttpPost]
        public IActionResult HousingAdd(HousingAddModel model)
        {
            if (ModelState.IsValid)
            {
                var housing = new ApartmentMng.Entities.Concrete.Housing
                {

                    HousingNo = model.HousingNo,
                    RentMoney = model.RentMoney,
                    ApartmentName = model.ApartmentName,
                };

                var result = _housingService.HousingAdd(housing);
                return RedirectToAction(nameof(HousingAdd));

            }
            return NotFound("hata");
        }
    }
}
