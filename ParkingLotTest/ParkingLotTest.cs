namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_ticket_when_parking_in_a_parkinglot_given_a_car()
        {
            ParkingLot parking = new ParkingLot();
            string ticket = parking.Park("car");
            Assert.Equal("q", ticket);
        }
    }
}
