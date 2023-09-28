using MachineMaintenanceWebAPI.Controllers;

namespace MachineMaintenanceWebAPI.Models
{
    public class MachineReport
    {
        public string MachineName { get; set; }

        public List<Failure> Failures { get; set; }

        public double AverageFailureTime { get; set; }

        public MachineReport(string machineName, List<Failure> failures, double averageFailureTime)
        {
            MachineName = machineName;
            Failures = failures;
            AverageFailureTime = averageFailureTime;
        }
    }
}