using MediatR;
using WheelzyChallenge.Application.UseCases.Cars.GetCarById.DTOs;
using WheelzyChallenge.Application.UseCases.Cars.GetCarById.Queries;
using WheelzyChallenge.Domain.Interfaces;

namespace WheelzyChallenge.Application.UseCases.Cars.GetCarById.Handlers
{
    public class GetCarByIdHandler(ICarRepository repo) : IRequestHandler<GetCarByIdQuery, CarDetailsDto?>
    {

        public async Task<CarDetailsDto?> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await repo.GetCarByIdAsync(request.CarId);

            if (car == null) return null;

            return new CarDetailsDto
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
            };
        }
    }
}
