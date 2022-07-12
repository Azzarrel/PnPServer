using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using PnPManager.Server.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PnPManager.Server.Data.Services
{
  public class UserRepository : IUserRepository
  {

    private DataBaseContext _Context { get; }


    public UserRepository(DataBaseContext context)
    {
      _Context = context;
    }

    public User Register(string userName, string password)
    {
      User newUser = new User();
      try
      {
        if(!_Context.Users.Any(u => u.Name == userName))
        {
          newUser.Name = userName;
          byte[] salt = new byte[128 / 8];
          newUser.Password = HashPassword(password, salt);
          newUser.Salt = salt;
          newUser.AuthToken = Guid.NewGuid().ToString();
          _Context.Users.Add(newUser);
          _Context.SaveChanges();
        }
      }
      catch { }

      return RemovePassword(newUser);
    }

    public User LogIn(string userName, string password)
    {

      User user = null;
      try
      {
        user = _Context.Users.FirstOrDefault(u => u.Name == userName);
        if(user != null)
        {
          if(user.Password == HashPassword(password, user.Salt))
             user.AuthToken = Guid.NewGuid().ToString();
        }
      }
      catch{}

      return RemovePassword(user);
    }

    private User RemovePassword(User user)
    {
      User userWithoutPassword = user.CreateCopy(); //Password can be erased after login.
      userWithoutPassword.Password = "";
      return user;
    }

    private string HashPassword(string password, byte[] salt)
    {

      RandomNumberGenerator.Fill(salt);

      Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

      // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
      string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 100000,
                numBytesRequested: 256 / 8));

      return hashed;

    }
  }
}
