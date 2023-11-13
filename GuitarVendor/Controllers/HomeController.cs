using GuitarVendor.Models;
using Microsoft.AspNetCore.Mvc;

namespace GuitarVendor.Controllers
{
  public class HomeController : Controller
  {

    // private readonly GuitarVendorContext _db;
    // public HomeController(GuitarVendorContext db)
    // {
    //   _db = db;
    // }

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }

  }
}