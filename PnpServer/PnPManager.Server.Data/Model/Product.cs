using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PnPManager.Server.Data.Model
{
  public class Product
  {
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public int Value { get; set; }

    //public ICollection<Material> Ingredients { get; set; }
  }
}
