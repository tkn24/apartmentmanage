using ApartmentMng.Business.Abstract;
using ApartmentMng.Models.Request.Apartment;

using Microsoft.AspNetCore.Mvc;

namespace ApartmentMng.UI.Controllers
{
    public class ApartmentsController : Controller
    {

        private readonly IApartmentService _apartmentService;  //dependency injection
        private readonly IPersonelService _personelService;

        public ApartmentsController(IApartmentService apartmentService, IPersonelService personelService)
        {
            _apartmentService = apartmentService;
            _personelService = personelService;
        }


        public IActionResult GetAllApartments()
        {
            if (ModelState.IsValid)
            {
                var result = _apartmentService.GetAllApartments();
                return View(result);
            }
            return NotFound("hata");
        }

        [HttpGet]
        public IActionResult ApartmentAdd()
        {

            var result = _personelService.GetAllPersonels();
            return View(result);

        }

        [HttpPost]
        public IActionResult ApartmentAdd(ApartmentAddModel model)
        {
            if (ModelState.IsValid)
            {
                var apartment = new ApartmentMng.Entities.Concrete.Apartment
                {

                    ApartmentName = model.ApartmentName,
                    City = model.City,
                    County = model.County,
                    Address = model.Address,
                    ApartmentManager = model.ApartmentManager
                };

                var result = _apartmentService.ApartmentAdd(apartment);
                return RedirectToAction(nameof(ApartmentAdd));

            }
            return NotFound("hata");
        }

    



    }
}
