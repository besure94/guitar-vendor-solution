using Microsoft.AspNetCore.Mvc;
using GuitarVendor.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http.Features;

namespace GuitarVendor.Controllers
{
  public class GuitarsController : Controller
  {
    private readonly GuitarVendorContext _db;
    public GuitarsController(GuitarVendorContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Guitar> model = _db.Guitars.ToList();
      return View(model);
    }

  }
}