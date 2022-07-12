using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PnPManager.Server.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnPManager.Server.Data
{
  public static class Factory
  {

    public static void AddServices(IServiceCollection services, DbContextOptions contextOption)
    {
      services.AddSingleton(contextOption);
      services.AddTransient<IUserRepository, UserRepository>();
      services.AddTransient<DataBaseContext>();
    }

    public static void ConfigureDatabase(IApplicationBuilder app)
    {
      var context = app.ApplicationServices.GetRequiredService<DataBaseContext>();
      context.Database.EnsureCreated();
      context.Database.Migrate();
    }
  }
}
