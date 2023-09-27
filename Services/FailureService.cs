using StrojeviAPI.Business;
using StrojeviAPI.Models;
using System.Xml.Linq;

namespace StrojeviAPI.Services
{
        public class FailureService
        {
            protected IDatabaseRepository DatabaseRepository;
            public FailureService(IDatabaseRepository databaseRepository)
            {

                DatabaseRepository = databaseRepository;
            }

            public List<Failure> GetFailures(FailureCollector failureCollector)
            {
                var failureListDynamic = DatabaseRepository.Read<Failure>(failureCollector.FailureName);
                var failureList = Utilities.ConvertToListFailure(failureListDynamic);
                List<Failure> sortedFailures = failureList
                .OrderBy(failure => failure.Priority) 
                .ThenByDescending(failure => failure.StartTime) 
                .ToList();

                List<Failure> filteredFailures = sortedFailures.Take(failureCollector.DesiredCount).ToList();

                return filteredFailures;
            }
            public List<Failure> processFailures(string machineName)
            {
                var failuresDynamic = DatabaseRepository.Read<Failure>(machineName);
                return Utilities.ConvertToListFailure(failuresDynamic).ToList();
            }
            public List<Failure> CheckFailures(List<Failure> failures)
            {
                foreach(var failure in failures)
                {
                    var failureChecked = Utilities.ConvertToListFailure(DatabaseRepository.Read<Failure>(failure.Name)).FirstOrDefault();
                    if(!failureChecked.IsRemoved) 
                    {
                        failures.Remove(failure);
                    }
                }

                return failures;
            }
            public int CreateFailures(List<Failure> failures)
            {
                var failuresChecked = CheckFailures(failures);
                return DatabaseRepository.Create(failuresChecked);
            }

            public Failure UpdateFailure(Failure failure, string failureName)
            {
                return DatabaseRepository.Update<Failure>(failureName, failure.MachineName, failure);
            }

            public Failure DeleteFailure(string name)
            {
                return DatabaseRepository.Delete<Failure>(name);
            }

            public Failure UpdateStatus(StatusUpdate statusUpdate)
            {
                var failuresDynamic = DatabaseRepository.Read<Failure>(statusUpdate.FailureName);
                var failure = Utilities.ConvertToListFailure(failuresDynamic).FirstOrDefault();
                failure.IsRemoved = statusUpdate.NewStatus;
                return DatabaseRepository.Update<Failure>(statusUpdate.FailureName,failure.MachineName,failure);
            }
        }
}
