using MediatR;
using WheelzyChallenge.Application.UseCases.Cars.GetCarsWithQuoteAndStatus.DTOs;

namespace WheelzyChallenge.Application.UseCases.Cars.GetCarsWithQuoteAndStatus.Queries
{
    public class GetCarsWithQuoteAndStatusQuery : IRequest<List<CarWithQuoteAndStatusDto>>
    {
    }
}
