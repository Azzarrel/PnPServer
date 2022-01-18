using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PnPManager.Server.Services
{
  public interface IDatabaseService
  {
    DataTable ExecuteSP(string sp, Dictionary<string, object> parameters);
    DataTable Login(string username, string password);
    DataTable Register(string username, string password);
  }
}
