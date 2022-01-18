using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace PnPManager.Server.Implementation
{
  public static class Factory
  {

    public static void AddServices(IServiceCollection services)
    {
      var  connectionString = new SqlConnectionStringBuilder()
      {
        DataSource = ".\\SQLEXPRESS",
        InitialCatalog = "dbPnPManager",
        UserID = "sa",
        Password = "PnPAdmin666",
      }.ConnectionString;
      var dbContextOptionsBuilder = new DbContextOptionsBuilder();

      dbContextOptionsBuilder.UseSqlServer(connectionString);



      Data.Factory.AddServices(services, dbContextOptionsBuilder.Options);
    }


  }
}
