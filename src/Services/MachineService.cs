using MachineMaintenanceWebAPI.Business;
using MachineMaintenanceWebAPI.Models;
using System.Data;
using System.Xml.Linq;

namespace MachineMaintenanceWebAPI.Services
{
    public class MachineService
    {
        protected IDatabaseRepository DatabaseRepository;
        public MachineService(IDatabaseRepository databaseRepository)
        {

            DatabaseRepository = databaseRepository;
        }
         
        public int ProcessTheList(List<Machine> machines)
        {
            var selectedMachines = DatabaseRepository.GetAllEntities<Machine>();
            var commonMachines = selectedMachines.Select(machine => machine.MachineName)
                                              .Intersect(machines.Select(machine => machine.MachineName))
                                              .ToList();
            var processedMachines = new List<Machine>();

            foreach(var machine in machines)
            {
                if(!commonMachines.Contains(machine.MachineName))
                {
                    processedMachines.Add(machine);
                }
            }
            return DatabaseRepository.Create(processedMachines);
        }
        
        public (MachineReport,int) GetMachineWithFailures(string machineName)
        {
            double averageTime = 0;
            var failuresDynamic = DatabaseRepository.ReadFailuresByMachineName(machineName);
            var failures = Utilities.ConvertToListFailure(failuresDynamic).ToList();
            foreach (Failure failure in failures)
            {
                TimeSpan timeDifference = failure.EndTime - failure.StartTime;

                averageTime = averageTime + timeDifference.TotalSeconds;
            }
            return (new MachineReport(machineName, failures, averageTime), 200);
        }

        public List<Machine> processMachine(string machineName)
        {
            var machinesDynamic = DatabaseRepository.Read<Machine>(machineName);
            return Utilities.ConvertToListMachine(machinesDynamic).ToList();
        }
        public Machine UpdateMachine(string machineName, string newMachineName)
        {
            return DatabaseRepository.Update<Machine>(machineName, newMachineName);
        }
       
        public Machine DeleteMachine(string machineName)
        {
            return DatabaseRepository.Delete<Machine>(machineName);
        }
    }
}
