using Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models.Dao;
using Models.Context;

namespace Web.Controllers;

public class AccountController(SignInManager<User> signInManager, UserManager<User> userManager) : Controller
{
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM model)
    {
        if (ModelState.IsValid)
        {
            //login
            var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, true,/* model.RememberMe,*/ false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Produits");
            }

            ModelState.AddModelError("", "Identifiants incorrects.");
            return View(model);
        }
        return View(model);
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM model)
    {
        if (ModelState.IsValid)
        {
            var User = new User()
            {
                UserName = model.Email,
                Email = model.Email,
            };

            // Lors de la création de l'utilisateur, création et association du panier
            var Panier = new Panier()
            {
                UserId = User.Id
            };

            var result = await userManager.CreateAsync(User, model.Password!);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(User, false);

                var factoryContext = new StiveContextFactory();
                using var context = factoryContext.CreateDbContext([]);
                context.Panier.Add(Panier);
                context.SaveChanges();

                return RedirectToAction("Index", "Produits");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index", "Produits");
    }
}
