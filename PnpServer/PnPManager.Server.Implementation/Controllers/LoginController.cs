using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PnPManager.Server.Data.Model;
using PnPManager.Server.Implementation.Services;
using PnPManager.Server.Model;
using System;
using System.Threading.Tasks;

namespace PnPManager.Server.Controllers
{

  [ApiController]
  [Route("login")]
  public class LoginController : ControllerBase
  {
    public ILoginService LoginService { get; private set; }

    public LoginController(ILoginService loginService)
    {

      LoginService = loginService;
    }

    [Produces(typeof(User))]
    [HttpPost("Login")]
    public IActionResult LogInUser(LoginCache login)
    {
      try
      {
        var result =  LoginService.Login(login);
        if(result == null)
          return StatusCode(500, "User Or Password Incorrect Found");

        return Ok(result);
      }
      catch(Exception e)
      {
        return StatusCode(500, e.Message);
      }
    }
    [Produces(typeof(User))]
    [HttpPut("Register")]
    public IActionResult RegisterUser(LoginCache login)
    {
      try
      {
        var result =  LoginService.Register(login);
        if(result == null)
          return StatusCode(500, "Error Creating User");
        return Ok(result);
      }
      catch(Exception e)
      {
        return StatusCode(500, e.Message);
      }
    }

  }
}
