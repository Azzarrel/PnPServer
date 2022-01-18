using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PnPManager.Server.Data.Model;

namespace PnPManager.Server.Data
{
  public class MaterialContext : DbContext
  {

    public DbSet<Material> Materials { get; set; }

    public DbSet<Product> Products { get; set; }

    public MaterialContext(DbContextOptions options)
             : base(options)
    { }


  }
}
