using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatadogKubernetes.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<AccountController> _logger;

        public AccountController(ILogger<AccountController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<AccountDetails> Get()
        {
             var accountDetails = new List<AccountDetails> { 
             new AccountDetails{ UserId = 1350 , AccountId = Guid.NewGuid().ToString() , Balance=75400 },
             new AccountDetails{ UserId = 1351 , AccountId = Guid.NewGuid().ToString() , Balance=75900 },
             new AccountDetails{ UserId = 1352 , AccountId = Guid.NewGuid().ToString() , Balance=95400 }
            };

            Serilog.ILogger Logger = LoggerExtensions.FileLogger();

            foreach (var account in accountDetails)
            {
                Logger.Information("account details for the user {@account}", account);
            }

            return accountDetails.ToArray();
        }
    }
}
