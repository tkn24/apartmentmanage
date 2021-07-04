using ApartmentMng.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApartmentMng.UI.Controllers
{
    
    public class PersonelsController : Controller
    {
        private readonly IPersonelService _personelService;  //dependency injection

        public PersonelsController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        [Authorize(Roles="admin")]  // 3 farklı auth yetkisi var!
        public IActionResult GetAllPersonels()
        {
            var result = _personelService.GetAllPersonels();
            return View(result);
        }

        [Route("getroles/{id}")]
        public async Task<IActionResult> GetRoles(string id)
        {
           
            return Json(await _personelService.GetPersonelRoles(id));
        }

        [Route("/update/personel/roles")]
        public async Task<IActionResult> UpdatePersonelRoles(string personelId, string [] personelRoleList)
        {
            var updated = await _personelService.UpdatePersonelRoles(personelId, personelRoleList);
            return Json(updated);
        }

    }
}
