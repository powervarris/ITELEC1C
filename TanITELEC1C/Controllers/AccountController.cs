using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TanITELEC1C.ViewModels;
using TanITELEC1C.Data;
using System.Diagnostics;

namespace TanITELEC1C.Controllers
{
    public class AccountController : Controller
    {

        private readonly SignInManager<users> _signInManager;
        private readonly UserManager<users> _userManager;

        public AccountController(SignInManager<users> signInManager, UserManager<users> userManager) //: this(signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginViewModel loginInfo)
        {

            var result = await _signInManager.PasswordSignInAsync(loginInfo.Username, loginInfo.Password, loginInfo.RememberMe, false);

                if(result.Succeeded)
            {

                return RedirectToAction("Index", "Instructor");
                
            }

            else
            {

                ModelState.AddModelError("", "Failed to login");

            }

                return View(loginInfo);

        }

        public async Task<IActionResult> Logout()
        {

            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Instructor");

        }

        [HttpGet]
        public IActionResult Register()
        {

            return View();

        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel userEnteredData)
        {

            
                
                users newUser = new users();
                newUser.UserName = userEnteredData.Username;
                newUser.firstName = userEnteredData.FirstName;
                newUser.lastName = userEnteredData.LastName;
                newUser.Email = userEnteredData.Email;
                newUser.PhoneNumber = userEnteredData.Phone;

                var result = await _userManager.CreateAsync(newUser, userEnteredData.Password);

                if(result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Instructor");

                }

                else
                {

                    foreach (var error in result.Errors) {
                        
                        ModelState.AddModelError("", error.Description);
                    
                    }
                    
                }
                
            

            return View(userEnteredData);

        }

    }
}
