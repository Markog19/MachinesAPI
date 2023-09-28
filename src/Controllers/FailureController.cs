using Microsoft.AspNetCore.Mvc;
using MachineMaintenanceWebAPI.Business;
using MachineMaintenanceWebAPI.Models;
using MachineMaintenanceWebAPI.Services;

namespace MachineMaintenanceWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FailureController : ControllerBase
    {
        protected IDatabaseRepository DatabaseRepository;
        protected FailureService FailureService;

        public FailureController(IDatabaseRepository databaseRepository, FailureService failureService)
        {

            DatabaseRepository = databaseRepository;
            FailureService = failureService;

    }
        [HttpPost]
        [Route("post")]
        public ActionResult CreateFailure([FromBody] List<Failure> failures)
        {
            var status = FailureService.CreateFailures(failures);
            if(status > 0)
            {
                return Ok("Success, failures inserted: " + status);
            }
            return BadRequest("Insert failed");
        }

        [HttpDelete]
        [Route("delete")]
        public ActionResult DeleteFailure([FromBody] string name)
        {
            var machine = FailureService.DeleteFailure(name);
            return Ok("Success: " + machine);

        }

        [HttpPut]
        [Route("put")]
        public ActionResult UpdateFailure([FromBody] FailureUpdater failureUpdater)
        {
            var result = FailureService.UpdateFailure(failureUpdater.Failure, failureUpdater.FailureName);
            return Ok(result);
        }

        [HttpGet]
        [Route("get")]
        public ActionResult GetFailure([FromBody] string name)
        {

            var failures = FailureService.processFailures(name);
            if (failures.Count() > 0)
            {
                return Ok(failures);
            }
            return BadRequest(failures);
        }

        [HttpPut]
        [Route("status")]
        public ActionResult UpdateStatus([FromBody] StatusUpdate statusUpdate)
        {
            var status = FailureService.UpdateStatus(statusUpdate);
            if(status.IsRemoved == statusUpdate.NewStatus)
            {
                return Ok();
            }
            return BadRequest();
        }

      

        [HttpGet]
        [Route("getFailures")]
        public ActionResult GetFailures([FromBody] FailureCollector failureCollector)
        {

            var status = FailureService.GetFailures(failureCollector);
            if (status.Count > 0)
            {
                return Ok(status);
            }
            return BadRequest(status);
        }
    }
}
