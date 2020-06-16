using ConfigurationOptions.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace ConfigurationOptions.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigurationController : ControllerBase
    {
        private ServiceConfiguration _service;

        public ConfigurationController(ServiceConfiguration service)
        {
            _service = service;
        }

        // GET: api/Configuration
        [HttpGet]
        public string Get()
        {
            return _service.GetConfigs();
        }
    }
}
