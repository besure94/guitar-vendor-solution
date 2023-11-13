using System.Collections.Generic;
using System;

namespace GuitarVendor.Models
{
  public class Guitar
  {
    public int GuitarId { get; set; }
    public int StoreId { get; set; }
    public string Brand { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }
    public string Type { get; set; }
    public int Price { get; set; }
    public int Year { get; set; }
    public Store Store { get; set; }
    public List<StoreGuitar> JoinEntities { get; }

  }
}