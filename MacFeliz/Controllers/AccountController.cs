using MacFeliz.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MacFeliz.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Login(string returnUrl)
        {
            return View(new LoginViewModel()
            {
                ReturnUrl = returnUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByNameAsync(loginVM.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(loginVM.ReturnUrl))
                    {
                        return Redirect(loginVM.ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError(string.Empty, "Nome de usuário ou senha inválidos");
            return View(loginVM);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(LoginViewModel registroVM)
        {
            var user = new IdentityUser { UserName = registroVM.UserName };
            var result = await _userManager.CreateAsync(user, registroVM.Password);

            if(result.Succeeded)
            {
               await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Login", "Account");
            }
            else
            {
                this.ModelState.AddModelError("Registro", "falha ao registrar o usuário");
            }

            return View(registroVM);
        }
    }
}
