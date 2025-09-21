namespace WheelzyChallenge.Domain.Entities
{
    public class CarQuote
    {
        public int Id { get; private set; }
        public int CarId { get; private set; }
        public int BuyerZipQuoteId { get; private set; }
        public bool IsCurrent { get; private set; }

        public Car Car { get; private set; } = null!;
        public BuyerZipQuote BuyerZipQuote { get; private set; } = null!;

        private CarQuote() { }

        public static CarQuote Create(int carId, int buyerZipQuoteId, bool isCurrent = false)
        {
            return new CarQuote
            {
                CarId = carId,
                BuyerZipQuoteId = buyerZipQuoteId,
                IsCurrent = isCurrent
            };
        }

        public void MarkAsCurrent() => IsCurrent = true;
        public void UnmarkCurrent() => IsCurrent = false;
    }
}
