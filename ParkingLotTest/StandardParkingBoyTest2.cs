using ParkingLotManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyTest2
    {
        [Theory]
        [InlineData("car")]
        public void Should_park_the_car_in_first_lot_if_available(string carName)
        {
            //Given
            List<ParkingLot> parkingLot = new List<ParkingLot>(new ParkingLot[2]
            {
                new ParkingLot(10),
                new ParkingLot(10),
            });
            StandardParkingBoy parkingBoy = new StandardParkingBoy(parkingLot);

            //When
            string ticket = parkingBoy.Park(carName);

            //Then
            Assert.Equal(9, parkingLot[0].GetParkingCapicity());
            Assert.Equal(10, parkingLot[1].GetParkingCapicity());
        }
    }
}
