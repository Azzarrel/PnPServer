using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using PnPManager.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PnPManager.Server.Hubs
{
  public class DatabaseHub : Hub
  {

    private DatabaseService m_DBService;

    public DatabaseHub(DatabaseService dbService)
    {
      m_DBService = dbService;
    }

    public Task SendMessage(string message)
    {
      return Clients.Others.SendAsync("ReceiveMessage", message);
    }

    public Task ExecuteSP(string sp, Dictionary<string, object> parameters)
    {

      var serialized = JsonConvert.SerializeObject(m_DBService.ExecuteSP(sp, parameters));
      return Clients.Caller.SendAsync("ExecuteSP", serialized);
    }

    public Task Login(string username, string password)
    {

      var serialized = JsonConvert.SerializeObject(m_DBService.Login(username, password));
      return Clients.Caller.SendAsync("Login", serialized);
    }  

  }
}
