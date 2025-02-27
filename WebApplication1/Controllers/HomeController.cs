using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication1.Models;
using WebApplication1.ViewModels;
using WebApplication1.Extensions;

namespace WebApplication1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<AppUser> _userManager;
    private readonly SignInManager<AppUser> _signInManager;

    public HomeController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _logger = logger;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult SignUp()
    {
        return View();
    }

    public IActionResult SignIn()
    {
        return View();
    }
       

    [HttpPost]
    public async Task<IActionResult> SignUp(SignUpViewModel request)
    {
        //if (!ModelState.IsValid)
        //{
        //    return View(request);
        //}

        //var newUser = new AppUser
        //{
        //    UserName = request.UserName,
        //    PhoneNumber = request.Phone,
        //    Email = request.Email
        //};




        if (!ModelState.IsValid)
        {
            return View();
        }


        var identityResult = await _userManager.CreateAsync(new() { UserName = request.UserName, PhoneNumber = request.Phone, Email = request.Email }, request.Password);

        


        if (identityResult.Succeeded)
        {
            TempData["SuccessMessage"] = "Kayýt baþarýyla gerçekleþti!";
            return RedirectToAction(nameof(HomeController.SignUp));
        }

        ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());

       

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(SignInViewModel model, string? returnUrl = null)
    {
        returnUrl= returnUrl ??= Url.Action("Index", "Home");

        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var hasUser = await _userManager.FindByEmailAsync(model.Email);

        if (hasUser == null)
        {
            ModelState.AddModelError(string.Empty, "Email veya þifre yanlýþ.");
            return View(model);
        }

        var result = await _signInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, true);

        if (result.Succeeded)
        {
            return RedirectToAction("Index", "Home"); // ? Giriþ baþarýlýysa Home/Index sayfasýna yönlendir
        }

        if (result.IsLockedOut)
        {
            ModelState.AddModelError(string.Empty, "3 dakika sonra tekrar deneyiniz");
            return View();

        }
        ModelState.AddModelError(string.Empty, "Email veya þifre yanlýþ.");
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
