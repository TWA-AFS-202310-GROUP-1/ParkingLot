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

        [Fact]
        public void Should_fetch_right_ticket_by_smartparkingboy_when_different_parkinglot_has_cars()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLot1, parkingLot2);

            string ticket1 = smartParkingBoy.StandardPark("car1");
            string ticket2 = smartParkingBoy.StandardPark("car2");
            string nowticket1 = smartParkingBoy.StandardFetch(ticket1);
            string nowticket2 = smartParkingBoy.StandardFetch(ticket2);
            Assert.Equal("car1", nowticket1);
            Assert.Equal("car2", nowticket2);
        }
    }
}
