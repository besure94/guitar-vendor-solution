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
      List<Guitar> model = _db.Guitars.Include(guitar => guitar.Store).ToList();
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
        _db.StoreGuitars.Add(new StoreGuitar() { StoreId = guitar.StoreId, GuitarId = guitar.GuitarId });
        _db.SaveChanges();
        return RedirectToAction("Index");
      }
    }

    public ActionResult Details(int id)
    {
      Guitar thisGuitar = _db.Guitars
      .Include(guitar => guitar.JoinEntities)
      .ThenInclude(guitar => guitar.Store)
      .FirstOrDefault(guitar => guitar.GuitarId == id);
      return View(thisGuitar);
    }

    public ActionResult AddStore(int id)
    {
      Guitar thisGuitar = _db.Guitars.FirstOrDefault(guitars => guitars.GuitarId == id);
      ViewBag.StoreId = new SelectList(_db.Stores, "StoreId", "Name");
      return View(thisGuitar);
    }

    [HttpPost]
    public ActionResult AddStore(Guitar guitar, int storeId)
    {
      #nullable enable
      StoreGuitar? joinEntity = _db.StoreGuitars.FirstOrDefault(join => (join.StoreGuitarId == storeId && join.GuitarId == guitar.GuitarId));
      #nullable disable
      if (joinEntity == null && storeId != 0)
      {
        _db.StoreGuitars.Add(new StoreGuitar() { StoreId = storeId, GuitarId = guitar.GuitarId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = guitar.GuitarId });
    }

    public ActionResult Edit(int id)
    {
      Guitar thisGuitar = _db.Guitars.FirstOrDefault(guitar => guitar.GuitarId == id);
      ViewBag.StoreId = new SelectList(_db.Stores, "StoreId", "Name");
      return View(thisGuitar);
    }

    [HttpPost]
    public ActionResult Edit(Guitar guitar)
    {
      _db.Guitars.Update(guitar);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Guitar thisGuitar = _db.Guitars.FirstOrDefault(guitar => guitar.GuitarId == id);
      return View(thisGuitar);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Guitar thisGuitar = _db.Guitars.FirstOrDefault(guitar => guitar.GuitarId == id);
      _db.Guitars.Remove(thisGuitar);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteJoin(int joinId)
    {
      StoreGuitar joinEntry = _db.StoreGuitars.FirstOrDefault(entry => entry.StoreGuitarId == joinId);
      _db.StoreGuitars.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}