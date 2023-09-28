using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MachineMaintenanceWebAPI.Business;
using MachineMaintenanceWebAPI.Models;
using MachineMaintenanceWebAPI.Services;

namespace MachineMaintenanceWebAPI.Controllers
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
        public ActionResult DeleteMachine([FromBody] string MachineName)
        {
            var machine = MachineService.DeleteMachine(MachineName);
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
