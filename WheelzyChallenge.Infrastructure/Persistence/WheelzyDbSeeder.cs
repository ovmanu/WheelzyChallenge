using System;
using System.Linq;
using WheelzyChallenge.Domain.Entities;

namespace WheelzyChallenge.Infrastructure.Persistence
{
    public static class WheelzyDbSeeder
    {
        public static void Seed(WheelzyDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Statuses.Any())
            {
                context.Statuses.AddRange(
                    Status.Create("Pending"),
                    Status.Create("Accepted"),
                    Status.Create("Picked Up")
                );
                context.SaveChanges();
            }

            if (!context.Buyers.Any())
            {
                var buyer1 = Buyer.Create("Buyer A");
                var buyer2 = Buyer.Create("Buyer B");

                context.Buyers.AddRange(buyer1, buyer2);
                context.SaveChanges();
            }

            if (!context.BuyerZipQuotes.Any())
            {
                var buyer1 = context.Buyers.First(b => b.Name == "Buyer A");
                var buyer2 = context.Buyers.First(b => b.Name == "Buyer B");

                var bzq1 = BuyerZipQuote.Create(buyer1.Id, "33101", 500);
                var bzq2 = BuyerZipQuote.Create(buyer1.Id, "90210", 480);
                var bzq3 = BuyerZipQuote.Create(buyer2.Id, "33101", 510);
                var bzq4 = BuyerZipQuote.Create(buyer2.Id, "10001", 700);

                context.BuyerZipQuotes.AddRange(bzq1, bzq2, bzq3, bzq4);
                context.SaveChanges();
            }

            if (!context.Cars.Any())
            {
                var car1 = Car.Create(2010, "Toyota", "Corolla", "LE", "33101");
                var car2 = Car.Create(2015, "Honda", "Civic", "EX", "33101");
                var car3 = Car.Create(2018, "Ford", "Focus", "SE", "90210");
                var car4 = Car.Create(2020, "Chevrolet", "Malibu", "LT", "10001");

                context.Cars.AddRange(car1, car2, car3, car4);
                context.SaveChanges();
            }

            if (!context.CarQuotes.Any())
            {
                var cars = context.Cars.ToList();
                var bzqs = context.BuyerZipQuotes.ToList();

                var cq1 = CarQuote.Create(cars[0].Id, bzqs[0].Id, true);  
                var cq2 = CarQuote.Create(cars[1].Id, bzqs[1].Id, true);
                var cq3 = CarQuote.Create(cars[2].Id, bzqs[2].Id, true);
                var cq4 = CarQuote.Create(cars[3].Id, bzqs[3].Id, true);

                context.CarQuotes.AddRange(cq1, cq2, cq3, cq4);
                context.SaveChanges();
            }

            if (!context.CarStatusHistories.Any())
            {
                var cars = context.Cars.ToList();
                var statuses = context.Statuses.ToList();

                var csh1 = CarStatusHistory.Create(cars[0].Id, statuses[0].Id, "system", null, false);
                var csh2 = CarStatusHistory.Create(cars[0].Id, statuses[1].Id, "system", DateTime.UtcNow.AddDays(-2), true);

                var csh3 = CarStatusHistory.Create(cars[1].Id, statuses[0].Id, "system", null, true);

                var csh4 = CarStatusHistory.Create(cars[2].Id, statuses[0].Id, "system", DateTime.UtcNow.AddDays(-7), false);
                var csh5 = CarStatusHistory.Create(cars[2].Id, statuses[2].Id, "system", DateTime.UtcNow.AddDays(-1), true);

                var csh6 = CarStatusHistory.Create(cars[3].Id, statuses[0].Id, "system", DateTime.UtcNow.AddDays(-10), false);
                var csh7 = CarStatusHistory.Create(cars[3].Id, statuses[1].Id, "system", DateTime.UtcNow.AddDays(-3), false);
                var csh8 = CarStatusHistory.Create(cars[3].Id, statuses[2].Id, "system", DateTime.UtcNow, true);

                context.CarStatusHistories.AddRange(csh1, csh2, csh3, csh4, csh5, csh6, csh7, csh8);
                context.SaveChanges();
            }

            if (!context.Customers.Any())
            {
                var customer1 = Customer.Create("Customer 1");
                var customer2 = Customer.Create("Customer 2");

                context.Customers.AddRange(customer1, customer2);
                context.SaveChanges();
            }

            if (!context.Orders.Any())
            {

                var customer1 = context.Customers.First();
                var customer2 = context.Customers.Skip(1).First();

                var order1 = Order.Create(customer1.Id, 1, true, DateTime.UtcNow.AddDays(-10), 1);
                var order2 = Order.Create(customer2.Id, 1, true, DateTime.UtcNow.AddDays(-5), 2);
                var order3 = Order.Create(customer1.Id, 2, false, DateTime.UtcNow.AddDays(-2), 3);

                context.Orders.AddRange(order1, order2, order3);
                context.SaveChanges();
            }
        }
    }
}
