using PnPManager.Server.Data.Model;

namespace PnPManager.Server.Data.Services
{
  public interface IMaterialRepository
  {
    bool Add(Material material);
    Material Get(int id);
    bool Remove(int id);
    void Remove(Material material);
  }
}
