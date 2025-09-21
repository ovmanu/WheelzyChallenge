namespace WheelzyChallenge.Domain.Entities
{
    public class Status
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = null!;

        public ICollection<CarStatusHistory> CarStatusHistories { get; private set; } = new List<CarStatusHistory>();

        private Status() { }

        public static Status Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Status name required");

            return new Status
            {
                Name = name
            };
        }
    }
}
