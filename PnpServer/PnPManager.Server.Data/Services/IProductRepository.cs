using PnPManager.Server.Data.Model;

namespace PnPManager.Server.Data.Services
{
  public interface IProductRepository
  {
    bool Add(Product product);
    bool AddIngredient(int prodId, int matId);
    Product Get(int id);
    bool Remove(int id);
    void Remove(Product product);
  }
}
