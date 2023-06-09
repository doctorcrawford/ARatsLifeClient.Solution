using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using ARatsLifeClient.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ARatsLifeClient.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Net;

namespace ARatsLifeClient.Controllers;

public class AccountsController : Controller
{
  // private readonly ARatsLifeClientContext _db;
  // private readonly UserManager<ApplicationUser> _userManager;
  // private readonly SignInManager<ApplicationUser> _signInManager;

  // public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ARatsLifeClientContext db)
  // {
  //   _userManager = userManager;
  //   _signInManager = signInManager;
  //   _db = db;
  // }

  // this HAS to be static because every time to you a RedirectToAction, you get a new Controller
  // :Facepalm
  private static string ErrorMessage = "";

  public ActionResult Index()
  {
    
    return View();
  }

  public ActionResult Register()
  {
    if (!string.IsNullOrEmpty(ErrorMessage))
    {
      ViewBag.ErrorMessage = ErrorMessage;
    }
    return View();
  }

  [HttpPost]
  public async Task<ActionResult> Register(RegisterViewModel model)
  {
    try
    {
      var tokenGrab = await ApplicationUser.RegisterAsync(model);
      // var cookieOptions = new CookieOptions();
      // cookieOptions.Expires = DateTime.Now.AddMinutes(5);
      // cookieOptions.Path = "/";
      // Response.Cookies.Append("TokeCookie", "SomeValue", cookieOptions);
      // var cookie = Response.Cookies
      return RedirectToAction("Index");
    }
    catch (KylesCustomException e)
    {
      // we threw this exception ourselves in ApiHelper.cs -- it is a handled case
      // we planned for it cus we're advanced programmers
      Console.WriteLine(e.Message);
      ErrorMessage = e.Message;
      return RedirectToAction("Register");
    }
    catch(Exception e)
    {
      // catch all for every exception that we did not plan for
      // dont know what happened here. something fucked up. maybe a NullReferenceException
      // catch it here so the whole application does not crash.
      Console.WriteLine(e.Message);
      return RedirectToAction("Index");
    }
  }

  public ActionResult Login()
  {
    return View();
  }

  // [HttpPost]
  // public ActionResult Login(LoginViewModel model)
  // {
  //   try
  //   {
  //     if (!ModelState.IsValid)
  //     {
  //       return View(model);
  //     }
  //     else
  //     {
  //       ApplicationUser.Login(model);
  //       return RedirectToAction("Index");
  //     }
  //   }
  //   catch (Exception e)
  //   {
  //     Console.WriteLine(e.Message);
  //     return RedirectToAction("Index");
  //   }
  // }




  
  //   [HttpPost]
  //   public async Task<ActionResult> Login(LoginViewModel model)
  //   {
  //     if (!ModelState.IsValid)
  //     {
  //       return View(model);
  //     }
  //     else
  //     {
  //       Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
  //       if (result.Succeeded)
  //       {
  //         return RedirectToAction("Index");
  //       }
  //       else
  //       {
  //         ModelState.AddModelError("", "There is something wrong with your email or username. Please try again.");
  //         return View(model);
  //       }
  //     }
  //   }

  //   [HttpPost]
  //   public async Task<ActionResult> LogOff()
  //   {
  //     await _signInManager.SignOutAsync();
  //     return RedirectToAction("Index");
  //   }
  // }
}