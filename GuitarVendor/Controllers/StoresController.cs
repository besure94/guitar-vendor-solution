using Microsoft.AspNetCore.Mvc;
using GuitarVendor.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

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
      if (store.Name == null || store.Description == null)
      {
        return RedirectToAction("Create");
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

  }
}