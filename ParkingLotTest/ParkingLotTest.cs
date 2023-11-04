namespace ParkingLotTest
{
    using ParkingLotSystem;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_ticket_when_park_car()
        {
            var parkingLot = new ParkingLot();
            var ticket = parkingLot.Park("Car1");
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_return_correct_car_when_fetch_car_given_a_ticket()
        {
            var parkingLot = new ParkingLot();
            var ticket = parkingLot.Park("Car1");
            string car = parkingLot.Fetch(ticket);
            Assert.Equal("Car1", car);
        }

             
    }
}
