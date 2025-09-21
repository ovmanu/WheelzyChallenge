using WheelzyChallenge.Domain.ReadModels;

namespace WheelzyChallenge.Domain.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<OrderReadModel>> GetOrdersAsync(
            DateTime? dateFrom,
            DateTime? dateTo,
            List<int>? customerIds,
            List<int>? statusIds,
            bool? isActive,
            CancellationToken cancellationToken = default);
    }
}
