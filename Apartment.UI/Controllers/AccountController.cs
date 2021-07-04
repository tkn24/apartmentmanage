using Apartment.UI.Controllers;
using ApartmentMng.Entities.Concrete;
using ApartmentMng.Models.Request.Account;
using AspNetCore.Identity.MongoDbCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApartmentMng.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Personel> _userManager;
        private readonly SignInManager<Personel> _signInManager;
        private readonly RoleManager<MongoIdentityRole> _roleManager;

        public AccountController(UserManager<Personel> userManager,
            RoleManager<MongoIdentityRole> roleManager,
            SignInManager<Personel> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCreateModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var user = new Personel
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    NameSurname = model.NameSurname,
                    Job=model.Job,
                    PhoneNumber=model.PhoneNumber

                };

                var result = await _userManager.CreateAsync(user, model.Password);
                /*
                if (result.Succeeded)
                {
                    var role = new MongoIdentityRole
                    {
                        Name = "apartmentManager",
                        NormalizedName = "APARTMENTMANAGER"
                    };
                    var resultRole = await _roleManager.CreateAsync(role);
                    await _userManager.AddToRoleAsync(user, "apartmentManager");
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToLocal(returnUrl);
                }*/
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();

        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }


        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToLocal(returnUrl);
                }

            }
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }




    }
}
