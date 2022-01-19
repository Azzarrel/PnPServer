using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PnPManager.Server.Data.Model
{
  public class User
  {


    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }


    public User()
    {
      Name = "";
    }
  }
}
