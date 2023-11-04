namespace ParkingLotTest
{
    using ParkingLot;
    using System.Reflection;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_a_ticket_when_park_car_given_a_car()
        {
            //given
            ParkingLot parking = new ParkingLot();
            string ticket = parking.Park("car");

            //when
            string result = parking.FetchCar(ticket);

            //then
            Assert.Equal("-car", ticket);
        }

        [Fact]
        public void Should_return_correct_car_when_fetch_car_given_a_ticket()
        {
            //given
            ParkingLot parking = new ParkingLot();
            string ticket = parking.Park("car");
            string ticket2 = parking.Park("car2");

            //when
            string result = parking.FetchCar(ticket);
            string result2 = parking.FetchCar(ticket2);

            //then
            //test the fetched cars
            Assert.Equal("car", result);
            Assert.Equal("car2", result2);
        }

        [Fact]
        public void Should_return_null_when_fetch_car_given_an_unvalid_ticket()
        {
            //given
            ParkingLot parking = new ParkingLot();
            string ticket = parking.Park("car");
            string unvalidTicket = "x";
            string unvalidTicket2 = null;

            //when
            //ticket number is wrong
            string result = parking.FetchCar(unvalidTicket);
            //ticket is null
            string result2 = parking.FetchCar(unvalidTicket2);

            //then
            Assert.Null(result);
            Assert.Null(result2);
        }

        [Fact]
        public void Should_return_null_when_get_car_in_a_parkinglot_with_cars_given_a_used_ticket()
        {
            //given
            ParkingLot parking = new ParkingLot();
            string ticket = parking.Park("car");
            string ticket2 = parking.Park("car2");

            //when
            string result = parking.FetchCar(ticket);
            string result2 = parking.FetchCar(ticket);

            //then
            //can fetch the correct car
            Assert.Equal("car", result);
            //cannot fetch any car since ticket is used
            Assert.Null(result2);
        }
    }
}
