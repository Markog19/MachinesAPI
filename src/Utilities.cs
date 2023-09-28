using MachineMaintenanceWebAPI.Models;

namespace MachineMaintenanceWebAPI
{
    public class Utilities
    {
        public static IEnumerable<Failure> ConvertToListFailure(IEnumerable<dynamic> failuresDynamic)
        { 
            List<Failure> list = new List<Failure>();
            foreach (var failureDynamic in failuresDynamic)
            {
                Failure failure = new Failure
                {
                    Id = failureDynamic.Id,
                    Name = failureDynamic.Name,
                    MachineName = failureDynamic.MachineName,
                    Priority = failureDynamic.Priority,
                    StartTime = failureDynamic.StartTime,
                    EndTime = failureDynamic.EndTime,
                    Description = failureDynamic.Description,
                    IsRemoved = failureDynamic.IsRemoved,
                };

                list.Add(failure);
            }
            return list;
        }

        public static IEnumerable<Machine> ConvertToListMachine(IEnumerable<dynamic> machinesDynamic)
        {
            List<Machine> list = new List<Machine>();
            foreach (var machineDynamic in machinesDynamic)
            {
                Machine machine = new Machine
                {
                    Id = machineDynamic.Id,
                    MachineName = machineDynamic.MachineName,
                    
                };

                list.Add(machine);
            }
            return list;
        }
    }
}
