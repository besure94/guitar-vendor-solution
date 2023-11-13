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

    public ActionResult Create()
    {
      ViewBag.StoreId = new SelectList(_db.Stores, "StoreId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Guitar guitar)
    {
      if (guitar.StoreId == 0 || guitar.Brand == null || guitar.Model == null || guitar.Color == null || guitar.Type == null || guitar.Price == 0)
      {
        return RedirectToAction ("Create");
      }
      else
      {
        _db.Guitars.Add(guitar);
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Guitar thisGuitar = _db.Guitars.FirstOrDefault(guitar => guitar.GuitarId == id);
      return View(thisGuitar);
    }

  }
}