namespace WheelzyChallenge.Application.UseCases.Cars.GetCarById.DTOs
{
    public class CarDetailsDto
    {
        public int CarId { get; set; }
        public int Year { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string SubModel { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public string BuyerName { get; set; } = null!;
        public decimal Quote { get; set; }
        public string CurrentStatus { get; set; } = null!;
        public DateTime? StatusDate { get; set; }
    }
}
