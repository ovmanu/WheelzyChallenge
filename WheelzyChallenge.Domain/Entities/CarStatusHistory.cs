namespace WheelzyChallenge.Domain.Entities
{
    public class CarStatusHistory
    {
        public int Id { get; private set; }
        public int CarId { get; private set; }
        public int StatusId { get; private set; }
        public string ChangedBy { get; private set; } = null!;
        public DateTime StatusDate { get; private set; }
        public bool IsCurrent { get; private set; }

        public Car Car { get; private set; } = null!;
        public Status Status { get; private set; } = null!;

        private CarStatusHistory() { }

        public static CarStatusHistory Create(int carId, int statusId, string changedBy, DateTime statusDate, bool isCurrent = false)
        {
            if (string.IsNullOrWhiteSpace(changedBy)) throw new ArgumentException("ChangedBy required");

            return new CarStatusHistory
            {
                CarId = carId,
                StatusId = statusId,
                ChangedBy = changedBy,
                StatusDate = statusDate,
                IsCurrent = isCurrent
            };
        }

        public void MarkAsCurrent() => IsCurrent = true;
        public void UnmarkCurrent() => IsCurrent = false;
    }
}
