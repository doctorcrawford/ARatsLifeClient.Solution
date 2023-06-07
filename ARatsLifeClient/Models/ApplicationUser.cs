using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using ARatsLifeClient.ViewModels;

namespace ARatsLifeClient.Models
{
  public class ApplicationUser : IdentityUser
  {
    public static void Register(RegisterViewModel model)
    {
      string jsonApplicationUser = JsonConvert.SerializeObject(model);
      ApiHelper.Register(jsonApplicationUser);
    }

    public static Task<string> Login(LoginViewModel model)
    {
      var userInfo = new string[] { model.Email, model.Password};
      string jsonUserInfo = JsonConvert.SerializeObject(userInfo);
      var result = ApiHelper.Login(jsonUserInfo);
      return result;
    }
  }
}