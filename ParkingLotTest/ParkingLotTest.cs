namespace ParkingLotTest
{
    using ParkingLot;
    using System.Reflection;
    using Xunit;
    using Xunit.Sdk;

    public class ParkingLotTest
    {
        [Theory]
        [InlineData("car")]
        public void Should_return_a_ticket_when_park_given_a_car(string car)
        {
            //given
            ParkingLot parkingLot = new ParkingLot();

            //when
            string ticket = parkingLot.Park(car);

            //then
            Assert.Equal($"-{car}", ticket);
        }

        [Fact]
        public void Should_return_correct_car_when_fetch_given_a_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");
            string ticket2 = parkingLot.Park("car2");

            //when
            string result = parkingLot.FetchCar(ticket);
            string result2 = parkingLot.FetchCar(ticket2);

            //then
            Assert.Equal("car", result);
            Assert.Equal("car2", result2);
        }

        [Theory]
        [InlineData("x")]
        [InlineData(null)]
        public void Should_throw_exception_when_fetch_car_given_an_unvalid_ticket(string unvalidTicket)
        {
            //given
            ParkingLot parkingLot = new ParkingLot();

            //when
            parkingLot.Park("car");

            //then
            Assert.Throws<UnvalidTicketException>(() => parkingLot.FetchCar(unvalidTicket));
        }

        [Fact]
        public void Should_throw_exception_when_fetch_car_given_a_used_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            //when
            string result = parkingLot.FetchCar(ticket);

            //then
            //can fetch the correct car at first time
            Assert.Equal("car", result);
            //cannot fetch any car since ticket is used
            Assert.Throws<UnvalidTicketException>(() => parkingLot.FetchCar(ticket));
        }

        [Fact]
        public void Should_not_return_ticket_when_park_given_a_full_parking_lot()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(3);

            //when
            for (int i = 0; i < 3; i++)
            {
                parkingLot.Park($"car{i}");
            }

            //then
            Assert.Throws<NoPositionException>(() => parkingLot.Park("car3"));
        }
    }
}
