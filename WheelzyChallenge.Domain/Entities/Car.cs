namespace WheelzyChallenge.Domain.Entities
{
    public class Car
    {
        public int Id { get; private set; }
        public int Year { get; private set; }
        public string Brand { get; private set; } = null!;
        public string Model { get; private set; } = null!;
        public string SubModel { get; private set; } = null!;
        public string ZipCode { get; private set; } = null!;

        public ICollection<CarQuote> Quotes { get; private set; } = new List<CarQuote>();
        public ICollection<CarStatusHistory> StatusHistory { get; private set; } = new List<CarStatusHistory>();

        private Car() { }

        public static Car Create(int year, string brand, string model, string subModel, string zipCode)
        {
            if (string.IsNullOrWhiteSpace(brand)) throw new ArgumentException("Brand required");
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Model required");
            if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentException("ZipCode required");

            return new Car
            {
                Year = year,
                Brand = brand,
                Model = model,
                SubModel = subModel,
                ZipCode = zipCode
            };
        }
    }
}
