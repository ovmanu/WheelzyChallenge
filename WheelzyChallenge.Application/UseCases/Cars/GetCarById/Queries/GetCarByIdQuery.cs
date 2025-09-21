using MediatR;
using WheelzyChallenge.Application.UseCases.Cars.GetCarById.DTOs;

namespace WheelzyChallenge.Application.UseCases.Cars.GetCarById.Queries
{
    public class GetCarByIdQuery : IRequest<CarDetailsDto?>
    {
        public int CarId { get; set; }
    }
}
