using Microsoft.AspNetCore.Mvc;
using StrojeviAPI.Models;

namespace StrojeviAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachinesController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<MachinesController> _logger;

        public MachinesController(ILogger<MachinesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Machine> GetMachine()
        {
            return null;
        }

        [HttpGet]
        public IEnumerable<Machine> GetAllMachines()
        {
            return null;
        }

        [HttpPost]
        public IEnumerable<Machine> AddMachine()
        {
            return null;
        }

        [HttpPost]
        public IEnumerable<Machine> AddMachinesBulk()
        {
            return null;
        }

        [HttpDelete]
        public IEnumerable<Machine> DeleteMachine()
        {
            return null;
        }

        [HttpPut]
        public IEnumerable<Machine> UpdateMachine()
        {
            return null;
        }
    }
}