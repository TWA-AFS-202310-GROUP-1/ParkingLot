using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyTest
    {
        [Fact]
        public void Should_get_a_ticket_when_park_given_car()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy boy = new StandardParkingBoy(parkingLot);

            string ticket = boy.Park("car1");

            Assert.Equal("T-car1", ticket);
        }

        [Fact]
        public void Should_get_a_car_when_fetch_given_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            StandardParkingBoy boy = new StandardParkingBoy(parkingLot);
            string ticket = boy.Park("car1");

            string car = boy.Fetch(ticket);

            Assert.Equal("car1", car);

        }
    }
}
