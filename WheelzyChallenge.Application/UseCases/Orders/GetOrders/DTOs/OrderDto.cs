namespace WheelzyChallenge.Application.UseCases.Orders.GetOrders.DTOs
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int StatusId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public decimal Total { get; set; }
    }
}