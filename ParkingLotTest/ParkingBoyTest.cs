using ParkingLotManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Theory]
        [InlineData("car")]
        public void Should_get_the_same_car_when_fetch_car_by_ticket(string carName)
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);

            //When
            string ticket = parkingBoy.Park(carName);
            string car = parkingBoy.Fetch(ticket);

            //Then
            Assert.Equal("car", car);
        }
    }
}
