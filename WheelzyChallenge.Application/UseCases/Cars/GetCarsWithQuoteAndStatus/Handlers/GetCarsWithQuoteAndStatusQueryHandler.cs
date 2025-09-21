using MediatR;
using WheelzyChallenge.Domain.Interfaces;
using WheelzyChallenge.Application.UseCases.Cars.GetCarsWithQuoteAndStatus.DTOs;
using WheelzyChallenge.Application.UseCases.Cars.GetCarsWithQuoteAndStatus.Queries;

namespace WheelzyChallenge.Application.UseCases.Cars.GetCarsWithQuoteAndStatus.Handlers
{
    public class GetCarsWithQuoteAndStatusQueryHandler(ICarRepository repo)
        : IRequestHandler<GetCarsWithQuoteAndStatusQuery, List<CarWithQuoteAndStatusDto>>
    {

        public async Task<List<CarWithQuoteAndStatusDto>> Handle(GetCarsWithQuoteAndStatusQuery request, CancellationToken cancellationToken)
        {
            var cars = await repo.GetCarsWithCurrentQuoteAndStatusAsync();

            return cars.Select(car => new CarWithQuoteAndStatusDto
            {
                CarId = car.CarId,
                Year = car.Year,
                Brand = car.Brand,
                Model = car.Model,
                SubModel = car.SubModel,
                ZipCode = car.ZipCode,
                BuyerName = car.BuyerName,
                Quote = car.Quote,
                CurrentStatus = car.CurrentStatus,
                StatusDate = car.StatusDate
            }).ToList();
        }
    }
}
