namespace ParkingLotTest
{
    using ParkingLot;
    using System.Reflection;
    using Xunit;
    using Xunit.Sdk;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_a_ticket_when_park_car_given_a_car()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            //when
            string result = parkingLot.FetchCar(ticket);

            //then
            Assert.Equal("-car", ticket);
        }

        [Fact]
        public void Should_return_correct_car_when_fetch_car_given_a_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");
            string ticket2 = parkingLot.Park("car2");

            //when
            string result = parkingLot.FetchCar(ticket);
            string result2 = parkingLot.FetchCar(ticket2);

            //then
            //test the fetched cars
            Assert.Equal("car", result);
            Assert.Equal("car2", result2);
        }

        [Fact]
        public void Should_throw_exception_when_fetch_car_given_an_unvalid_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");

            //when
            string unvalidTicket = "x";
            string unvalidTicket2 = null;

            //then
            Assert.Throws<UnvalidTicketException>(() => parkingLot.FetchCar(unvalidTicket));
            Assert.Throws<UnvalidTicketException>(() => parkingLot.FetchCar(unvalidTicket2));
        }

        [Fact]
        public void Should_throw_exception_when_fetch_car_given_a_used_ticket()
        {
            //given
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");
            string ticket2 = parkingLot.Park("car2");

            //when
            string result = parkingLot.FetchCar(ticket);

            //then
            //can fetch the correct car at first time
            Assert.Equal("car", result);
            //cannot fetch any car since ticket is used
            Assert.Throws<UnvalidTicketException>(() => parkingLot.FetchCar(ticket));
        }

        [Fact]
        public void Should_not_return_ticket_when_park_car_given_a_full_parking_lot()
        {
            //given
            ParkingLot parkingLot = new ParkingLot(3);
            for (int i = 0; i < 3; i++)
            {
                string tempTicket = parkingLot.Park($"car{i}");
                Assert.Equal($"-car{i}", tempTicket);
            }

            //when

            //then
            Assert.Throws<NoPositionException>(() => parkingLot.Park("car3"));
        }
    }
}
