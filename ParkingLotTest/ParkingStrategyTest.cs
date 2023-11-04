using ParkingLot2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingStrategyTest
    {
        [Fact]
        public void Should_return_right_ticket_by_SmartParking_Strategy()
        {
            var smartStrategy = new SmartParkingStrategy();
            var parkingLots = new List<ParkingLot>
            {
                new ParkingLot(),
                new ParkingLot()
            };

            string car1 = "Car1";
            string car2 = "Car2";
            string ticket1 = smartStrategy.Park(car1, parkingLots);
            string ticket2 = smartStrategy.Park(car2, parkingLots);

            Assert.NotNull(ticket1);
            Assert.NotNull(ticket2);
        }

        [Fact]
        public void Should_return_right_ticket_by_StandardParking_Strategy()
        {
            var standardStrategy = new StandardParkingStrategy();
            var parkingLots = new List<ParkingLot>
            {
                new ParkingLot(),
                new ParkingLot()
            };

            string car1 = "Car1";
            string car2 = "Car2";
            string ticket1 = standardStrategy.Park(car1, parkingLots);
            string ticket2 = standardStrategy.Park(car2, parkingLots);

            Assert.NotNull(ticket1);
            Assert.NotNull(ticket2);
        }
    }
}
