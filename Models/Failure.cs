namespace StrojeviAPI.Models
{
    public class Failure
    {

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MachineName { get; set; }
        public int Priority { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Description { get; set; }
        public bool IsRemoved { get; set; }

    }
}
