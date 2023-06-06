using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace ARatsLifeClient.Models;

public class Rat
{
  public int RatId { get; set; }
  public string Name { get; set; }
  [Range(0, Int16.MaxValue, ErrorMessage = "The field {0} must be a non negative integer")]
  public int Heat { get; set; }
  public int IndentoryId { get; set; }

  public static List<Rat> GetRats()
  {
    var apiCallTask = ApiHelper.GetAll();
    var result = apiCallTask.Result;

    JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
    List<Rat> ratList = JsonConvert.DeserializeObject<List<Rat>>(jsonResponse.ToString());

    return ratList; 
  }
}