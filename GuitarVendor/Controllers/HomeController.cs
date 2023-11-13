using Microsoft.AspNetCore.Mvc;

namespace GuitarVendor.Controllers
{
  public class HomeController : Controller
  {

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
}