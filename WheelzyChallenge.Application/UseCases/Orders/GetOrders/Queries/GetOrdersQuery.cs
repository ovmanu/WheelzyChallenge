using MediatR;
using WheelzyChallenge.Domain.ReadModels;

namespace WheelzyChallenge.Application.UseCases.Orders.Queries
{
    public class GetOrdersQuery : IRequest<List<OrderReadModel>>
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public List<int>? CustomerIds { get; set; }
        public List<int>? StatusIds { get; set; }
        public bool? IsActive { get; set; }
    }
}
