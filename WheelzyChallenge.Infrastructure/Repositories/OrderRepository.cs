using Microsoft.EntityFrameworkCore;
using WheelzyChallenge.Domain.Interfaces;
using WheelzyChallenge.Domain.ReadModels;
using WheelzyChallenge.Infrastructure.Persistence;

namespace WheelzyChallenge.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly WheelzyDbContext _context;

        public OrderRepository(WheelzyDbContext context)
        {
            _context = context;
        }

        public async Task<List<OrderReadModel>> GetOrdersAsync(
            DateTime? dateFrom,
            DateTime? dateTo,
            List<int>? customerIds,
            List<int>? statusIds,
            bool? isActive,
            CancellationToken cancellationToken = default)
        {
            var query = _context.Orders.AsQueryable();

            if (dateFrom.HasValue)
                query = query.Where(o => o.CreatedDate >= dateFrom.Value);

            if (dateTo.HasValue)
                query = query.Where(o => o.CreatedDate <= dateTo.Value);

            if (customerIds != null && customerIds.Any())
                query = query.Where(o => customerIds.Contains(o.CustomerId));

            if (statusIds != null && statusIds.Any())
                query = query.Where(o => statusIds.Contains(o.StatusId));

            if (isActive.HasValue)
                query = query.Where(o => o.IsActive == isActive.Value);

            return await query
                .Select(o => new OrderReadModel
                {
                    Id = o.Id,
                    CustomerId = o.CustomerId,
                    StatusId = o.StatusId,
                    IsActive = o.IsActive,
                    CreatedDate = o.CreatedDate,
                    Total = o.Total
                })
                .ToListAsync(cancellationToken);
        }
    }
}
