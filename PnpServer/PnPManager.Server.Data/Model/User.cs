using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PnPManager.Server.Data.Model
{
  public class User
  {

    [Key]
    public int ID { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public byte[] Salt { get; set; }

    [NotMapped]
    public string AuthToken { get; set; }

    public bool IsAdmin { get; set; }

    public User()
    {

    }

    public User(int iD, string name, string password)
    {
      ID = iD;
      Name = name;
      Password = password;
    }


  }
}
