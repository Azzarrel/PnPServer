using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PnPManager.Server.Data.Model
{
  public class Material
  {


    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public int Value { get; set; }

  }
}
