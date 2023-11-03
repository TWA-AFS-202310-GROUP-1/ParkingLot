using Xunit;
using ParkingLotManagement;

namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_the_same_car_when_fetch_car_by_ticket()
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            //When
            string car = parkingLot.Fetch(ticket);

            //Then
            Assert.Equal("car", car);
        }

        [Fact]
        public void Should_get_the_right_car_when_fetch_car_by_ticket()
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");

            //When
            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);

            //Then
            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_get_null_when_fetch_car_by_wrong_ticket()
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            //When
            string car = parkingLot.Fetch(ticket + "-T");

            //Then
            Assert.Null(car);
        }

        [Fact]
        public void Should_get_null_when_fetch_car_without_ticket()
        {
            //Given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            //When
            string car = parkingLot.Fetch(null);

            //Then
            Assert.Null(car);
        }
    }
}
