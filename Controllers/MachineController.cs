using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrojeviAPI.Business;
using StrojeviAPI.Models;
using StrojeviAPI.Services;

namespace StrojeviAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MachineController : ControllerBase
    {
        protected MachineService MachineService;
        public MachineController(MachineService machineService) { 
        
            MachineService = machineService;
        }
        [HttpPost]
        [Route("post")]
        public ActionResult CreateMachine([FromBody] List<Machine> machines)
        {
            if(MachineService.ProcessTheList(machines) > 0)
            {
                return Ok();
            }
            return BadRequest();

        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteMachine([FromQuery] string name)
        {
            var machine = MachineService.DeleteMachine(name);
            return Ok(machine);

        }

        [HttpPut]
        [Route("put")]
        public ActionResult PutMachine([FromBody] MachineUpdater machineUpdater)
        {
            var status = MachineService.UpdateMachine(machineUpdater.OldMachineName, machineUpdater.NewMachineName);
            return Ok(status);
        }


        [HttpGet]
        [Route("getMachines")]
        public ActionResult GetMachines([FromBody] Machine machine) 
        {
           var values = MachineService.GetMachineWithFailures(machine.MachineName);
           if(values.Item2 == 200)
            {
                return Ok(values.Item1);
            }
            else
            {
                return BadRequest();
            }
        }        
    }
}
