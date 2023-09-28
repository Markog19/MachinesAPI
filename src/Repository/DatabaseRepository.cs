using Dapper;
using Npgsql;
using MachineMaintenanceWebAPI.Models;
using System.Data;
using System.Linq;
using System.Xml.Linq;

namespace MachineMaintenanceWebAPI.Business
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly IDbConnection _dbConnection;

        public DatabaseRepository()
        {
            _dbConnection = new NpgsqlConnection("Host=localhost;Port=5432;Username=postgres;Password=12345678;Database=testtask");
            _dbConnection.Open();
        }

        public int Create<T>(List<T> entities) where T : class
        {

            
            if (typeof(T) == typeof(Machine))
            {
                var query = "INSERT INTO \"Machine\"(\"MachineName\") VALUES(@MachineName);";
                int n = _dbConnection.Execute(query, entities);
                return n;
            }
            else
            {
                var query = "INSERT INTO \"Failure\" (\"Name\", \"MachineName\", \"Priority\", \"StartTime\", \"EndTime\", \"Description\", \"IsRemoved\")\r\nVALUES (@Name, @MachineName, @Priority, @StartTime, @EndTime, @Description, @IsRemoved);";
                int n = _dbConnection.Execute(query, entities);
                return n;
            }
           
        }

        public List<T> GetAllEntities<T>() where T : class
        {
            string? query;
            if (typeof(T) == typeof(Machine))
            {
                query = "SELECT * FROM public.\"Machine\";";

            }
            else
            {
                query = "SELECT * FROM public.\"Failure\"";
            }
            return (List<T>)_dbConnection.Query<T>(query);

        }

        public T Delete<T>(string name) where T : class
        {
            if (typeof(T) == typeof(Machine))
            {
                string query = "DELETE FROM public.\"Machine\" WHERE \"MachineName\" = @MachineName;";
                var status =  _dbConnection.QuerySingleOrDefault<T>(query, new { MachineName = name });
                _dbConnection.Close();
                return status;

            }
            else
            {
                string query = "DELETE FROM public.\"Failure\" WHERE \"Name\" = @FailureName;";
                var status = _dbConnection.QueryFirstOrDefault<T>(query, new { FailureName = name });
                _dbConnection.Close();
                return status;
            }
        }


        public IEnumerable<dynamic> Read<T>(string name) where T : class
        {
            if (typeof(T) == typeof(Machine))
            {
                string query = "SELECT * FROM public.\"Machine\" WHERE \"MachineName\" = @MachineName;";
                return _dbConnection.Query(query, new { MachineName = name });

            }
            else
            {
                string query = "SELECT * FROM public.\"Failure\" WHERE \"Name\" = @FailureName;";
                return _dbConnection.Query(query, new { FailureName = name });

            }
        }

        public IEnumerable<dynamic> ReadFailuresByMachineName(string machineName)
        {
            string query = "SELECT * FROM public.\"Failure\" WHERE \"MachineName\" = @machineName;";
            var list = _dbConnection.Query(query, new { MachineName = machineName });
            _dbConnection.Close();
            return list;

        }

        public T Update<T>(string name, string newMachineName, Failure failure = null) where T : class
        {
            
            if (typeof(T) == typeof(Machine))
            {
                string query = "UPDATE public.\"Machine\" SET \"MachineName\"=@MachineName WHERE \"MachineName\"=@Name;";
                return _dbConnection.QuerySingleOrDefault(query, new { MachineName = newMachineName, Name = name });

            }
            else
            {
                string query = "UPDATE public.\"Failure\" SET \"Name\"=@newFailureName, \"MachineName\"=@newMachineName, \"Priority\"=@priority, \"StartTime\"=@startTime, \"EndTime\"=@endTime, \"Description\"=@description, \"IsRemoved\"=@isRemoved WHERE \"Name\"=@name;";
                return _dbConnection.QuerySingleOrDefault(query, new{
                   newFailureName =  failure.Name, 
                    newMachineName = newMachineName, 
                    priority = failure.Priority, 
                    startTime = failure.StartTime, 
                    endTime = failure.EndTime, 
                    description = failure.Description,
                    isRemoved = failure.IsRemoved, 
                    name = name
                });
            }
        }
    }
}
