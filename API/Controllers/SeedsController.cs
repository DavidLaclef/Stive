using Models.Context;
using Models.Dao;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

/// <summary>
/// Controleur permettant de créer le jeu de données initial
/// à utiliser après une migration 
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class SeedsController : ControllerBase
{
    private readonly StiveContext _context;
    private readonly UserManager<User> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public SeedsController(StiveContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // POST: api/Seeds/CreateRoles
    [HttpPost]
    [Route("CreateRoles")]
    public async Task<ActionResult<bool>> PostCreateRoles()
    {
        if (!(await _roleManager.RoleExistsAsync("Administrateur")))
        {
            await _roleManager.CreateAsync(new IdentityRole("Administrateur"));
        }
        if (!(await _roleManager.RoleExistsAsync("Utilisateur")))
        {
            await _roleManager.CreateAsync(new IdentityRole("Utilisateur"));
        }
        return true;
    }

    // POST: api/Seeds/CreateUsers
    [HttpPost]
    [Route("CreateUsers")]
    public async Task<ActionResult<bool>> PostCreateUsers()
    {
        //Création d'un utilisateur admin
        if (!_userManager.Users.Where(u => u.UserName == "Admin2").Any() && await _roleManager.RoleExistsAsync("Administrateur"))
        {
            var user = new User();
            user.UserName = "Admin2";
            user.Email = "admin_2@stive.fr";
            string userPWD = "AdminStive2.";

            IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

            //ajout du rôle Admin    
            if (chkUser.Succeeded)
            {
                var result = await _userManager.AddToRoleAsync(user, "Administrateur");
            }
        }

        //Création d'un utilisateur user
        if (!_userManager.Users.Where(u => u.UserName == "Zack").Any() && await _roleManager.RoleExistsAsync("Utilisateur"))
        {
            var user = new User();
            user.UserName = "Zack";
            user.Email = "Zack@mail.fr";
            string userPWD = "Zack1.";

            IdentityResult chkUser = await _userManager.CreateAsync(user, userPWD);

            //ajout du rôle Utilisateur
            if (chkUser.Succeeded)
            {
                var result = await _userManager.AddToRoleAsync(user, "Utilisateur");
            }
        }
        return true;
    }
}
