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

        [Theory]
        [InlineData("car1", "car2")]
        public void Should_get_the_right_car_when_fetch_car_by_ticket(string carName1, string carName2)
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            ParkingBoy parkingBoy = new ParkingBoy(parkingLot);

            //When
            string ticket1 = parkingBoy.Park(carName1);
            string ticket2 = parkingBoy.Park(carName2);
            string car1 = parkingBoy.Fetch(ticket1);
            string car2 = parkingBoy.Fetch(ticket2);

            //Then
            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }
    }
}
