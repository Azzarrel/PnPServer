using PnPManager.Server.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PnPManager.Server.Data.Services
{
  public class UserRepository : IUserRepository
  {

    public LoginContext Context { get; private set; }


    public UserRepository(LoginContext context)
    {
      Context = context;
    }

    public bool Add(User user)
    {
      Context.Materials.Add(user);
      Context.SaveChanges();
      return true;
    }

    public void Remove(User user)
    {
      Context.Materials.Remove(user);
      Context.SaveChanges();
    }

    public bool Remove(int id)
    {
      var mat = Get(id);
      if(mat != null)
      {

        Context.Materials.Remove(mat);
        Context.SaveChanges();
        return true;
      }
      return false;
    }

    public User Get(int id)
    {
      return Context.Materials.FirstOrDefault(m => m.Id == id);
    }

    public User Get(string name)
    {
      return Context.Materials.FirstOrDefault(m => m.Name == name);
    }

    public User Get(string name, string password)
    {
      return Context.Materials.FirstOrDefault(m => m.Name == name && m.Password == password);
    }




  }
}
