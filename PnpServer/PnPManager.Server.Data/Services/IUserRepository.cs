using PnPManager.Server.Data.Model;

namespace PnPManager.Server.Data.Services
{
  public interface IUserRepository
  {
    bool Add(User user);

    bool Remove(int id);
    void Remove(User user);

    User Get(int id);

    User Get(string name);

    User Get(string name, string password);
  }
}
