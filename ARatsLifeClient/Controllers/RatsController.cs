using Microsoft.AspNetCore.Mvc;
using ARatsLifeClient.Models;

namespace ARatsLifeClient.Controllers;

public class RatsController : Controller
{
  public IActionResult Index()
  {
    List<Rat> rats = Rat.GetRats();
    return View(rats);
  }
}
