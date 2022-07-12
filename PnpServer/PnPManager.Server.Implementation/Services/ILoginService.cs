using PnPManager.Server.Data.Model;
using PnPManager.Server.Model;

namespace PnPManager.Server.Implementation.Services
{
  public interface ILoginService
  {
    User Login(LoginCache cache);
    User Register(LoginCache cache);
  }
}
