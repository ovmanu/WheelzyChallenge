using MediatR;
using WheelzyChallenge.Application.UseCases.Orders.Queries;
using WheelzyChallenge.Domain.Interfaces;
using WheelzyChallenge.Domain.ReadModels;
using WheelzyChallenge.Infrastructure.Repositories;

namespace WheelzyChallenge.Application.UseCases.Orders.Handlers
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, List<OrderReadModel>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<List<OrderReadModel>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrdersAsync(
                request.DateFrom,
                request.DateTo,
                request.CustomerIds,
                request.StatusIds,
                request.IsActive,
                cancellationToken);
        }
    }
}
