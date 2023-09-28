using MachineMaintenanceWebAPI.Models;

namespace MachineMaintenanceWebAPI.Business
{
    public interface IDatabaseRepository
    {
        // Create a new failure
        int Create<T>(List<T> entity) where T : class;

        // Read a failure by its unique identifier
        IEnumerable<dynamic> Read<T>(string name) where T : class;

        // Update an existing failure
        T Update<T>(string name, string newMachineName, Failure failure = null) where T : class;

        // Delete a failure by its unique identifier
        T Delete<T>(string name) where T : class;

        public List<T> GetAllEntities<T>() where T : class;
        public IEnumerable<dynamic> ReadFailuresByMachineName(string machineName);

    }
}
