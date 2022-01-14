using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PnpServer.Services
{
  public interface IDatabaseService
  {
    DataTable ExecuteSP(string sp, Dictionary<string, object> parameters);
    DataTable Login(string username, string password);
    DataTable Register(string username, string password);
  }
}
