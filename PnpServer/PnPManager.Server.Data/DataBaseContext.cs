using Microsoft.EntityFrameworkCore;
using PnPManager.Server.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnPManager.Server.Data
{
  public class DataBaseContext : DbContext
  {
    public DbSet<User> Users { get; set; }


    public DataBaseContext(DbContextOptions options)
             : base(options)
    { }

  }
}
