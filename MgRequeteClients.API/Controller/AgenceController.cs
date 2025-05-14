using Microsoft.AspNetCore.Mvc;
using MgRequeteClients.API.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MgRequeteClients.API.Controller
{
    [Route("Agence.svc/")]
    
    public class AgenceController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AgenceController> _logger;

        public AgenceController(IConfiguration configuration, ILogger<AgenceController> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Test réussi");
        }

        [HttpPost("ajouter")]
        public IActionResult AjouterAgence([FromBody] MgRequeteClients.DTO.BusinessObjects.clsAgence agence)
        {
            _logger.LogInformation("Endpoint appelé");
            var service = new wsAgence(_configuration);
            var result = service.AjouterAgence(agence);
            return Ok(result);
        }

        // GET: api/<AgenceController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<AgenceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AgenceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AgenceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AgenceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
