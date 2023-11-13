using System.Collections.Generic;
using System;

namespace GuitarVendor.Models
{
  public class Store
  {
    public int StoreId { get; set; }
    public string Name {get; set; }
    public string Description { get; set; }
    public List<Guitar> Guitars { get; set; }
    public List<StoreGuitar> JoinEntities { get; }

  }
}