using System.Collections.Generic;
using System;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;
using ARatsLifeClient.ViewModels;
// using System.Text.Json;

namespace ARatsLifeClient.Models
{
  public class ApplicationUser : IdentityUser
  {
    public async static Task<DTOGoodAccount> RegisterAsync(RegisterViewModel model)
    {
      var response = await ApiHelper.RegisterAsync(model);
      return response;
    }

    // public static Task<string> Login(LoginViewModel model)
    // {
    //   var userInfo = new string[] { model.Email, model.Password};
    //   var jsonUserInfo = JsonConvert.SerializeObject(userInfo);
    //   var result = ApiHelper.Login(jsonUserInfo);
    //   return result;
    // }
  }
}