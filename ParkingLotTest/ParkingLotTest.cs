using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_the_same_car_when_fetch_car_given_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            string car = parkingLot.Fetch(ticket);

            Assert.Equal("car", car);
        }

        [Fact]
        public void Should_get_correct_car_when_fetch_car_given_corresponding_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");

            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_not_get_a_car_when_fetch_car_given_wrong_ticket_or_without_a_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");

            string car1 = parkingLot.Fetch("T-car2");
            string car2 = parkingLot.Fetch(string.Empty);

            Assert.Equal(string.Empty, car1);
            Assert.Equal(string.Empty, car2);
        }
    }
}
