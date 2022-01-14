using PnpServer.Model;
using System.Threading.Tasks;

namespace PnpServer.Services
{
    public interface ILoginService
    {
        User Login(LoginCache login);

        User Register(LoginCache login);
    }
}
