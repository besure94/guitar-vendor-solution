using GuitarVendor.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace GuitarVendor.Controllers
{
  public class HomeController : Controller
  {

    private readonly GuitarVendorContext _db;
    public HomeController(GuitarVendorContext db)
    {
      _db = db;
    }

    [HttpGet("/")]
    public ActionResult Index()
    {
      Store[] stores = _db.Stores.ToArray();
      Guitar[] guitars = _db.Guitars.ToArray();
      Dictionary<string, object[]> model = new Dictionary<string, object[]>();
      model.Add("stores", stores);
      model.Add("guitars", guitars);
      return View(model);
    }

  }
}