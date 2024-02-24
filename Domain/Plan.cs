namespace Domain
{
    public class Plan
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<SchreduledPlan>? SchreduledTimes { get; set; }
        public string? Description { get; set; }
        public List<Chrono> Chronos { get; set; }

    }
}
