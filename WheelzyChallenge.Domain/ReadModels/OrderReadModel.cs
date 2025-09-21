namespace WheelzyChallenge.Domain.ReadModels
{
    public class OrderReadModel
    {
        public int Id { get; init; }
        public int CustomerId { get; init; }
        public int StatusId { get; init; }
        public bool IsActive { get; init; }
        public DateTime CreatedDate { get; init; }
        public decimal Total { get; init; }
    }
}
