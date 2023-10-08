namespace Domain
{
    public class Plan
    {
        private long id;
        private string name;
        private List<DateTime> schreduledTimes;
        private string description;
        private List<Chrono> chronos;

        public long Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public List<DateTime> SchreduledTimes { get => schreduledTimes; set => schreduledTimes = value; }
        public string Description { get => description; set => description = value; }
        internal List<Chrono> Chronos { get => chronos; set => chronos = value; }
    }
}
