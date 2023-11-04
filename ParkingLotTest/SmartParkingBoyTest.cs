using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_park_into_more_empty_parkinglot_when_new_car_come()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLot1, parkingLot2);

            string ticket1 = smartParkingBoy.SmartPark("car1");
            string ticket2 = smartParkingBoy.SmartPark("car2");

            Assert.Equal("T-car2-in-parkingLot2", ticket2);
        }
    }
}
