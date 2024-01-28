using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GameStore.Models;
using GameStore.Resources;
using GameStore.Resources.Base;

namespace GameStore.Controllers
{
    [Route("api/[controller]")]
    public class LogginController : BaseController
    {
        private static bool loggingEnabled = false;

        [HttpPost]
        [Route("toggle_logging")]
        public IActionResult ToggleLogging()
        {
            loggingEnabled = !loggingEnabled;
            return Ok($"Logging {(loggingEnabled ? "enabled" : "disabled")}");
        }
    }
}