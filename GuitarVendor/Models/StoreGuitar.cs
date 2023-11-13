namespace GuitarVendor.Models
{
  public class StoreGuitar
  {
    public int StoreGuitarId { get; set; }
    public int StoreId { get; set;}
    public Store Store { get; set; }
    public int GuitarId { get; set; }
    public Guitar Guitar { get; set; }

  }
}