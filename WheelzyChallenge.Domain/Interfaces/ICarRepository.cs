using System.Collections.Generic;
using System.Threading.Tasks;
using WheelzyChallenge.Domain.ReadModels;

namespace WheelzyChallenge.Domain.Interfaces
{
    public interface ICarRepository
    {
        Task<List<CarWithQuoteAndStatus>> GetCarsWithCurrentQuoteAndStatusAsync();
        Task<CarWithQuoteAndStatus?> GetCarByIdAsync(int carId);
    }
}
