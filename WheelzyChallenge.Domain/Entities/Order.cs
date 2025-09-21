using WheelzyChallenge.Domain.Entities;

public class Order
{
    public int Id { get; private set; }
    public int CustomerId { get; private set; }
    public int StatusId { get; private set; }
    public bool IsActive { get; private set; }
    public DateTime CreatedDate { get; private set; }
    public decimal Total { get; private set; }

    public Customer Customer { get; private set; } = null!;

    private Order() { }

    public static Order Create(int customerId, int statusId, bool isActive, DateTime createdDate, decimal total)
    {
        return new Order
        {
            CustomerId = customerId,
            StatusId = statusId,
            IsActive = isActive,
            CreatedDate = createdDate,
            Total = total
        };
    }
}
