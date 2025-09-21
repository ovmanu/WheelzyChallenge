namespace WheelzyChallenge.Domain.Entities
{
    public class Buyer
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = null!;

        public ICollection<BuyerZipQuote> BuyerZipQuotes { get; private set; } = new List<BuyerZipQuote>();

        private Buyer() { }

        public static Buyer Create(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required");

            return new Buyer
            {
                Name = name
            };
        }
    }
}