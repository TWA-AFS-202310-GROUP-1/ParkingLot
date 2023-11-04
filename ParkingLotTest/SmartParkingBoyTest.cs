using ParkingLotManagement;
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
        [Theory]
        [InlineData("car")]
        public void Should_park_the_car_in_parkinglot_with_most_empty_positions(string carName)
        {
            //Given
            List<ParkingLot> parkingLot = new List<ParkingLot>(new ParkingLot[2]
            {
                new ParkingLot(2),
                new ParkingLot(5),
            });
            SmartParkingBoy parkingBoy = new SmartParkingBoy(parkingLot);

            //When
            string ticket = parkingBoy.Park(carName);

            //Then
            Assert.Equal(2, parkingLot[0].GetParkingCapicity());
            Assert.Equal(4, parkingLot[1].GetParkingCapicity());
        }
    }
}
