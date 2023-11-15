using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace GuitarVendor.Models
{
  public class Store
  {
    public int StoreId { get; set; }

    [Required(ErrorMessage = "The store's name can't be empty!")]
    public string Name {get; set; }

    [Required(ErrorMessage = "The store's description can't be empty!")]
    public string Description { get; set; }
    public List<Guitar> Guitars { get; set; }
    public List<StoreGuitar> JoinEntities { get; }

  }
}