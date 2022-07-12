using Microsoft.AspNetCore.Mvc;
using PnPManager.Server.Data.Model;
using PnPManager.Server.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PnPManager.Server.Implementation.Controllers
{
  [Route("api/[controller]")]
  public class LogInController : Controller
  {


    private IUserRepository _UserRepository { get; set; }

    public LogInController(IUserRepository userRepo)
    {
      _UserRepository = userRepo;
    }

    [HttpPut("Register/{userName}")]
    [Produces(typeof(User))]
    public IActionResult Register(string userName,[FromBody] string password)
    {
      try
      {
       var user = _UserRepository.Register(userName, password);
        if(user == null)
          return StatusCode(403, "unknown error during registration");

        if(user.Name == "")
          return StatusCode(403, "Name already taken");

        return Ok(user);
      }
      catch(Exception ex)
      {
        return StatusCode(403, ex.Message);
      }
    }

    [HttpPut("LogIn/{userName}")]
    [Produces(typeof(User))]
    public IActionResult LogIn(string userName, [FromBody] string password)
    {
      try
      {
        var user = _UserRepository.LogIn(userName, password);
        if(user == null)
          return StatusCode(403, "unknown error during registration");

        if(user.AuthToken == "")
          return StatusCode(403, "Wrong Name or Password");

        return Ok(user);
      }
      catch(Exception ex)
      {
        return StatusCode(403, ex.Message);
      }
    }
  }
}
