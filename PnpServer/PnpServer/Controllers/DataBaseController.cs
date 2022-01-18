﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PnPManager.Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PnPManager.Server.Controllers
{

  [ApiController]
  [Route("[database]")]
  public class DataBaseController : ControllerBase
  {
    private readonly ILogger<DataBaseController> _logger;

    public DataBaseController(ILogger<DataBaseController> logger, IDatabaseService dbConnection)
    {
      _logger = logger;
    }
  }
}
