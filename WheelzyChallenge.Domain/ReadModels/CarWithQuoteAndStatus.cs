namespace WheelzyChallenge.Domain.ReadModels
{
    public class CarWithQuoteAndStatus
    {
        public int CarId { get; init; }
        public string Brand { get; init; } = "";
        public string Model { get; init; } = "";
        public string SubModel { get; init; } = "";
        public int Year { get; init; }
        public string ZipCode { get; init; } = "";
        public string BuyerName { get; init; } = "";
        public decimal Quote { get; init; }
        public string CurrentStatus { get; init; } = "";
        public DateTime? StatusDate { get; init; }
    }
}
