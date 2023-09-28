using System.Text.Json.Serialization;

namespace MachineMaintenanceWebAPI.Models
{
    public class Machine 
    {
        public int Id { get; set; }
        public string MachineName { get; set; }

    }
}