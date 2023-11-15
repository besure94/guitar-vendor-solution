using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace GuitarVendor.Models
{
  public class Guitar
  {
    public int GuitarId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "You must add a guitar to a store. Have you created a store yet?")]
    public int StoreId { get; set; }

    [Required(ErrorMessage = "The guitar's brand can't be empty!")]
    public string Brand { get; set; }

    [Required(ErrorMessage = "The guitar's model can't be empty!")]
    public string Model { get; set; }

    [Required(ErrorMessage = "The guitar's color can't be empty!")]
    public string Color { get; set; }

    [Required(ErrorMessage = "The guitar's type can't be empty!")]
    public string Type { get; set; }

    [Required(ErrorMessage = "The guitar's price can't be empty!")]
    public int Price { get; set; }

    [Required(ErrorMessage = "The guitar's year can't be empty!")]
    public int Year { get; set; }
    public Store Store { get; set; }
    public List<StoreGuitar> JoinEntities { get; }

  }
}