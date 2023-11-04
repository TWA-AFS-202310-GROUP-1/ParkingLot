namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_correct_car_when_get_car_in_a_parkinglot_with_cars_given_a_ticket()
        {
            //given
            ParkingLot parking = new ParkingLot();
            string ticket = parking.Park("car");
            string ticket2 = parking.Park("car2");
            string unvalidTicket = "x";
            string unvalidTicket2 = null;

            //when
            string result = parking.FetchCar(ticket);
            string result2 = parking.FetchCar(ticket2);

            //then
            //test the tickets
            Assert.Equal("-car", ticket);
            Assert.Equal("-car2", ticket2);
            //test the fetched cars
            Assert.Equal("car", result);
            Assert.Equal("car2", result2);
            //test unvlid tickets
            Assert.Equal("wrong ticket", parking.FetchCar(unvalidTicket));
            Assert.Equal("null ticket", parking.FetchCar(unvalidTicket2));
        }
    }
}
