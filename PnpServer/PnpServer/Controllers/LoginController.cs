using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PnpServer.Model;
using PnpServer.Services;
using System;
using System.Threading.Tasks;

namespace PnpServer.Controllers
{

  [ApiController]
  [Route("login")]
  public class LoginController : ControllerBase
  {
    private readonly ILogger<DataBaseController> m_Logger;
    private readonly ILoginService m_LoginService;

    public LoginController(ILogger<DataBaseController> logger, ILoginService loginService)
    {
      m_Logger = logger;
      m_LoginService = loginService;
    }


    [HttpPost("Login")]
    public IActionResult LogInUser(LoginCache login)
    {
      try
      {
        var result =  m_LoginService.Login(login);
        if(result == null)
          return StatusCode(500, "User Or Password Incorrect Found");

        return Ok(result);
      }
      catch(Exception e)
      {
        return StatusCode(500, e.Message);
      }
    }

    [HttpPut("Register")]
    public IActionResult RegisterUser(LoginCache login)
    {
      try
      {
        var result =  m_LoginService.Register(login);
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
