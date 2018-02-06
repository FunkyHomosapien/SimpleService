using Microsoft.AspNetCore.Mvc;
using Serilog;
using SimpleService.Models;
using SimpleService.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SimpleService.Controllers
{
    [Route("api/[controller]")]
    public class HealthController : ControllerBase
    {
        private readonly IApplicationHealthService _applicationHealthService;
        private readonly IServerHealthService _serverHealthService;
        private readonly IDatabaseHealthService _databaseHealthService;
        private readonly IDateTimeService _dateTimeService;
        private readonly ILogger _logger;

        public HealthController(IApplicationHealthService applicationHealthService, IServerHealthService serverHealthService, IDatabaseHealthService databaseHealthService, IDateTimeService dateTimeService, ILogger logger)
        {
            _applicationHealthService = applicationHealthService;
            _serverHealthService = serverHealthService;
            _databaseHealthService = databaseHealthService;
            _dateTimeService = dateTimeService;
            _logger = logger;
        }

        // GET: api/Health
        [HttpGet]
        public HealthIndicator Get()
        {
            _logger.Information("Health endpoint called.");
            return new HealthIndicator(_applicationHealthService.IsApplicationHealthy(),
                _serverHealthService.IsServerHealthy(),
                _databaseHealthService.IsDatabaseHealthy(),
                _serverHealthService.Hostname,
                _dateTimeService.Now());
        }
    }
}
