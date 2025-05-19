using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Simulation2_7_25.BL.ViewModels;
using Simulation2_7_25.DAL.Enums;
using Simulation2_7_25.DAL.Models;

namespace Simulation2_7_25.MVC.Controllers;
public class AccountController : Controller
{
    public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    private readonly SignInManager<AppUser> _signInManager;
    private readonly UserManager<AppUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    #region Register
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        AppUser appUser = new()
        {
            Name = vm.Name,
            Email = vm.Email,
            UserName = vm.Username,
            Surname = vm.Surname,
        };

        var result = await _userManager.CreateAsync(appUser, vm.Password);

        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError("", error.Description);
            return View(vm);
        }

        await _userManager.AddToRoleAsync(appUser, UserRole.Member.ToString());

        return RedirectToAction("Index", "Home");
    }
    #endregion

    #region Login
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM vm, string? ReturnUrl)
    {
        if (!ModelState.IsValid)
            return View(vm);

        var user = await _userManager.FindByEmailAsync(vm.EmailOrUsername) ??
                   await _userManager.FindByNameAsync(vm.EmailOrUsername);

        if (user is null)
        {
            ModelState.AddModelError("", "Password or username is wrong");
            return View(vm);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, vm.Password, true);

        if (result.IsLockedOut)
        {
            ModelState.AddModelError("", "Please try again later");
            return View(vm);
        }

        if (!result.Succeeded)
        {
            ModelState.AddModelError("", "Password or username is wrong");
            return View(vm);
        }

        await _signInManager.SignInAsync(user, vm.Remember);

        if (ReturnUrl is not null)
            return Redirect(ReturnUrl);

        return RedirectToAction("Index", "Home");
    }
    #endregion

    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    public async Task<IActionResult> CreateRoles()
    {
        if (_roleManager.Roles.Count() == 0)
            foreach (UserRole role in Enum.GetValues(typeof(UserRole)))
                await _roleManager.CreateAsync(new IdentityRole(role.ToString()));
        return RedirectToAction("Index", "Home");
    }
}
