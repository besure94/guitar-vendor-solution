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
  }
}