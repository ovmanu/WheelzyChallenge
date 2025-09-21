using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WheelzyChallenge.Domain.Entities;
using WheelzyChallenge.Domain.Interfaces;
using WheelzyChallenge.Domain.ReadModels;
using WheelzyChallenge.Infrastructure.Persistence;

namespace WheelzyChallenge.Infrastructure.Repositories
{
    public class CarRepository : ICarRepository
    {
        private readonly WheelzyDbContext _context;

        public CarRepository(WheelzyDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarWithQuoteAndStatus>> GetCarsWithCurrentQuoteAndStatusAsync()
        {
            return await (
                from c in _context.Cars
                join cq in _context.CarQuotes on c.Id equals cq.CarId
                join bzq in _context.BuyerZipQuotes on cq.BuyerZipQuoteId equals bzq.Id
                join b in _context.Buyers on bzq.BuyerId equals b.Id
                join csh in _context.CarStatusHistories on c.Id equals csh.CarId
                join s in _context.Statuses on csh.StatusId equals s.Id
                where cq.IsCurrent && csh.IsCurrent
                select new CarWithQuoteAndStatus
                {
                    CarId = c.Id,
                    Year = c.Year,
                    Brand = c.Brand,
                    Model = c.Model,
                    SubModel = c.SubModel,
                    ZipCode = c.ZipCode,
                    BuyerName = b.Name,
                    Quote = bzq.Amount,
                    CurrentStatus = s.Name,
                    StatusDate = csh.StatusDate
                }
            ).ToListAsync();
        }

        public async Task<CarWithQuoteAndStatus?> GetCarByIdAsync(int carId)
        {
            return await (
                from c in _context.Cars
                join cq in _context.CarQuotes on c.Id equals cq.CarId
                join bzq in _context.BuyerZipQuotes on cq.BuyerZipQuoteId equals bzq.Id
                join b in _context.Buyers on bzq.BuyerId equals b.Id
                join csh in _context.CarStatusHistories on c.Id equals csh.CarId
                join s in _context.Statuses on csh.StatusId equals s.Id
                where c.Id == carId && cq.IsCurrent && csh.IsCurrent
                select new CarWithQuoteAndStatus
                {
                    CarId = c.Id,
                    Year = c.Year,
                    Brand = c.Brand,
                    Model = c.Model,
                    SubModel = c.SubModel,
                    ZipCode = c.ZipCode,
                    BuyerName = b.Name,
                    Quote = bzq.Amount,
                    CurrentStatus = s.Name,
                    StatusDate = csh.StatusDate
                }
            ).FirstOrDefaultAsync();
        }
    }
}
