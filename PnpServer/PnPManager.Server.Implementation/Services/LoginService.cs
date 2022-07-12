using PnPManager.Server.Data.Model;
using PnPManager.Server.Data.Services;
using PnPManager.Server.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnPManager.Server.Implementation.Services
{
  public class LoginService : ILoginService
  {


    public IUserRepository UserProvider { get; private set; }

    public LoginService(IUserRepository userProvider)
    {
      UserProvider = userProvider;
    }


    public User Login(LoginCache cache)
    {
      try
      {
        return UserProvider.Get(cache.UserName, cache.Password);
      }
      catch(Exception e)
      {
        throw;
      }

    }

    public User Register(LoginCache cache)
    {
      try
      {
        User alreadyExistingUser = UserProvider.Get(cache.UserName);
        if(alreadyExistingUser == null)
          UserProvider.Add(new User { Name = cache.UserName, Password = cache.Password });
        return UserProvider.Get(cache.UserName, cache.Password);
      }
      catch(Exception e)
      {
        throw;
      }
    }

  }
}
