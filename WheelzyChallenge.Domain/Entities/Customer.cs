namespace WheelzyChallenge.Domain.Entities
{
    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = null!;
        public ICollection<Order> Orders { get; private set; } = new List<Order>();

        private Customer() { }

        public static Customer Create(string name)
        {
            return new Customer { Name = name };
        }
    }
}
