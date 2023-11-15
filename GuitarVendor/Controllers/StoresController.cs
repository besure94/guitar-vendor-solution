using Microsoft.AspNetCore.Mvc;
using GuitarVendor.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GuitarVendor.Controllers
{
  public class StoresController : Controller
  {
    private readonly GuitarVendorContext _db;
    public StoresController(GuitarVendorContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Store> model = _db.Stores.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Store store)
    {
      if (!ModelState.IsValid)
      {
        return View(store);
      }
      _db.Stores.Add(store);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Store thisStore = _db.Stores
      .Include(guitar => guitar.JoinEntities)
      .ThenInclude(store => store.Guitar)
      .FirstOrDefault(store => store.StoreId == id);
      return View(thisStore);
    }

    public ActionResult Edit(int id)
    {
      Store thisStore = _db.Stores.FirstOrDefault(store => store.StoreId == id);
      return View(thisStore);
    }

    [HttpPost]
    public ActionResult Edit(Store store)
    {
      _db.Stores.Update(store);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      Store thisStore = _db.Stores.FirstOrDefault(store => store.StoreId == id);
      return View(thisStore);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Store thisStore = _db.Stores.FirstOrDefault(stores => stores.StoreId == id);
      _db.Stores.Remove(thisStore);
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

    public ActionResult AddGuitar(int id)
    {
      Store thisStore = _db.Stores.FirstOrDefault(stores => stores.StoreId == id);
      ViewBag.GuitarId = new SelectList(_db.Guitars, "GuitarId", "Year", "Brand", "Model");
      return View(thisStore);
    }

    [HttpPost]
    public ActionResult AddGuitar(Store store, int guitarId)
    {
      #nullable enable
      StoreGuitar? joinEntity = _db.StoreGuitars.FirstOrDefault(join => join.StoreGuitarId == guitarId && join.StoreId == store.StoreId );
      #nullable disable
      if (joinEntity == null && guitarId != 0)
      {
        _db.StoreGuitars.Add(new StoreGuitar() { GuitarId = guitarId, StoreId = store.StoreId });
        _db.SaveChanges();
      }
      return RedirectToAction("Details", new { id = store.StoreId });
    }

  }
}