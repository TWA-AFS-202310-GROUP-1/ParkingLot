using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLotManagement;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_the_same_car_when_fetch_car_by_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            string car = parkingLot.Fetch(ticket);

            Assert.Equal("car", car);
        }
    }
}
