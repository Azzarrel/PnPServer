using PnPManager.Server.Model;
using System.Threading.Tasks;

namespace PnPManager.Server.Services
{
    public interface ILoginService
    {
        User Login(LoginCache login);

        User Register(LoginCache login);
    }
}
