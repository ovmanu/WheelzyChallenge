namespace WheelzyChallenge.Domain.Entities
{
    public class BuyerZipQuote
    {
        public int Id { get; private set; }
        public int BuyerId { get; private set; }
        public string ZipCode { get; private set; } = null!;
        public decimal Amount { get; private set; }

        public Buyer Buyer { get; private set; } = null!;
        public ICollection<CarQuote> CarQuotes { get; private set; } = new List<CarQuote>();

        private BuyerZipQuote() { }

        public static BuyerZipQuote Create(int buyerId, string zipCode, decimal amount)
        {
            if (string.IsNullOrWhiteSpace(zipCode)) throw new ArgumentException("ZipCode required");
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be greater than zero");

            return new BuyerZipQuote
            {
                BuyerId = buyerId,
                ZipCode = zipCode,
                Amount = amount
            };
        }

        public void ChangeAmount(decimal newAmount)
        {
            if (newAmount <= 0) throw new ArgumentOutOfRangeException(nameof(newAmount));
            Amount = newAmount;
        }
    }
}
