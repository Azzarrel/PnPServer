using PnPManager.Server.Data.Model;

namespace PnPManager.Server.Data.Services
{
  public interface IUserRepository
  {
    User LogIn(string userName, string password);
    User Register(string userName, string password);
  }
}