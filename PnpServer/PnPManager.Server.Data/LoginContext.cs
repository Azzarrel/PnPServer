using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using PnPManager.Server.Data.Model;

namespace PnPManager.Server.Data
{
  public class LoginContext : DbContext
  {

    public DbSet<User> Materials { get; set; }

    public DbSet<Product> Products { get; set; }

    public LoginContext(DbContextOptions options)
             : base(options)
    { }


  }
}
