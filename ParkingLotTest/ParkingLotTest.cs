namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_ticket_when_park_in_a_parkinglot_given_a_car()
        {
            ParkingLot parking = new ParkingLot();
            string ticket = parking.Park("car");
            Assert.Equal("q", ticket);
        }

        [Fact]
        public void Should_return_correct_car_when_get_car_in_a_parkinglot_given_a_ticket()
        {
            ParkingLot parking = new ParkingLot();
            string ticket = parking.Park("car");

            string result = parking.GetCar(ticket);
            string result2 = parking.GetCar("x");

            Assert.Equal("car", result);
            Assert.Equal("wrong ticket", result2);
        }
    }
}
