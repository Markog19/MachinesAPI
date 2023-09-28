using StrojeviAPI.Business;
using StrojeviAPI.Models;

namespace TestApi
{
    public class UnitTests
    {
        public readonly DatabaseRepository  databaseRepository = new DatabaseRepository();
        // reorganize Tests folders
        [Fact]
        public void RepositoryLayerCreatesMachines()
        {
            var list = new List<Machine>();
            for (int i = 0; i < 3; i++)
            {
                Machine machine = new Machine
                {
                    Id = i,
                    MachineName = "test" + i,

                }; list.Add(machine);

            }
            var n = databaseRepository.Create(list);

            Assert.True(n == list.Count);
        }
        [Fact]
        public void RepositoryLayerFetchesMachines()
        {
            var machine = databaseRepository.GetAllEntities<Machine>();
            Assert.True(machine.Count > 0);
        }

        [Fact]
        public void RepositoryLayerFailsFetchFailuresByMachineName()
        {
            var failures = databaseRepository.ReadFailuresByMachineName("test1");
            Assert.False(failures.Count() > 0);
        }
    }
}