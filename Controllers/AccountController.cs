using Microsoft.AspNetCore.Mvc;
using RunGroopWebApp.Models;
using RunGroopWebApp.Data;
using RunGroopWebApp.ViewModels;
using Microsoft.AspNetCore.Identity;
namespace RunGroopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;
        
        /* Need a constructor to perform depandency Injection */
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        /* 
            If you reload the page accidentally it would bring back in all the data
        */
        public IActionResult Login( )
        {
            var response = new LoginViewModel( );

            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult>Login(LoginViewModel loginViewModel)
        {
            if(!ModelState.IsValid) return View(loginViewModel);
            
            var user = await _userManager.FindByEmailAsync(loginViewModel.EmailAddress);

            if(user != null)
            {
                // user is found, check password
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginViewModel.Password);
                if(passwordCheck)
                {
                    //Password correct, sign in
                    var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                    if(result.Succeeded)
                    {
                        return RedirectToAction("Index", "Race");
                    }
                }
                // Password is incorrect
                TempData["Error"] = "Wrong credentials. Please, try again";
                return View(loginViewModel);
            }
            //User not found
            TempData["Error"] = "Wrong credentials. Please try again";
            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register( )
        {
            var response = new RegisterViewModel( );
            return View( );
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            /* 
                If you don't know what ModelState is a static class that provides information about model state.
                Modelstate is when you post(sometimes get) what is gonna happen is the values that you post or you sent to the
                controller or end point is going to be passed in logically into registerViewModel. Imagine like it is coming in through
                your web page and the web page is going to insert those values into this function it will put those values into 
                registerViewModel
            */
            if(!ModelState.IsValid) return View(registerViewModel);

            /* This function will return an AppUser object or null */
            var user = await _userManager.FindByEmailAsync(registerViewModel.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerViewModel);
            }
            var newUser = new AppUser( )
            {
                Email = registerViewModel.EmailAddress,
                UserName = registerViewModel.EmailAddress
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerViewModel.Password);
            if(newUserResponse.Succeeded)
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
        
            return RedirectToAction("Index", "Race");
        }
        [HttpPost]
        public async Task<IActionResult> Logout( )
        {
            await _signInManager.SignOutAsync( );
            return RedirectToAction("Index", "Race");
        }
    }
}