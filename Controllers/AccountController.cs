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
        public IEnumerable<JhaLog> Get()
        {
            var currentTime = DateTime.Now.ToString();
            var guid = Guid.NewGuid().ToString();

            var outputCollection = new List<JhaLog>();

            var jhaLogCollection = new List<JhaLog>
            {
                new JhaLog { Id="1" , ApplicationName="WebApp" , BusinessCorrelationId= guid,
                Category="Cat1" , ClientTimeZone = currentTime , CorrelationId =guid,
                EventDateTime = currentTime , IPAddress="10.1.9.102" , Message="Sample message" ,MessageCode="MSG01",
                MessageFormat="Form1" , MessageType="Type1" , ProcessId = "1" , ProductName = "Product1" , RequestId = "RequestId",
                ServerTimeZone = currentTime,ThreadId = guid,WorkflowCorrelationId = guid
                }
            };

            for (int k = 0; k < 2; k++)
            {
                for (int i = 0; i < 5000; i++)
                {
                    jhaLogCollection.Add(new JhaLog
                    {
                        Id = "ID"+k+i,
                        ApplicationName = "WebApp",
                        BusinessCorrelationId = guid,
                        Category = "Cat1",
                        ClientTimeZone = currentTime,
                        CorrelationId = guid,
                        EventDateTime = currentTime,
                        IPAddress = "10.1.9.102",
                        Message = "Sample message",
                        MessageCode = "MSG01",
                        MessageFormat = "Form1",
                        MessageType = "Type1",
                        ProcessId = "ID" + k + i,
                        ProductName = "Product1",
                        RequestId = "RequestId",
                        ServerTimeZone = currentTime,
                        ThreadId = guid,
                        WorkflowCorrelationId = guid
                    });
                }
            }

            jhaLogCollection.Add(new JhaLog
            {
                Id = "2",
                ApplicationName = "WebApp",
                BusinessCorrelationId = guid,
                Category = "Cat1",
                ClientTimeZone = currentTime,
                CorrelationId = guid,
                EventDateTime = currentTime,
                IPAddress = "10.1.9.102",
                Message = "Sample message",
                MessageCode = "MSG01",
                MessageFormat = "Form1",
                MessageType = "Type1",
                ProcessId = "1",
                ProductName = "Product1",
                RequestId = "RequestId",
                ServerTimeZone = currentTime,
                ThreadId = guid,
                WorkflowCorrelationId = guid
            });


            Serilog.ILogger Logger = LoggerExtensions.ConsoleLogger();

            foreach (var log in jhaLogCollection)
            {
                Logger.Information("transaction details {@log}", log);
            }

            return outputCollection.ToArray();
        }
    }
}
