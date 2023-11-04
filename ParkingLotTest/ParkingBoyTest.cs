namespace ParkingLotTest
{
    using ParkingLot;
    using System.Reflection;
    using Xunit;
    using Xunit.Sdk;

    public class ParkingBoyTest
    {
        [Fact]
        public void Should_return_a_ticket_when_park_car_by_parking_boy_given_a_car()
        {
            //given
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();

            //when
            string ticket = standardParkingBoy.Park("car");

            //then
            Assert.Equal("-car", ticket);
        }

        [Fact]
        public void Should_return_correct_result_when_fetch_car_by_parking_boy_given_a_ticket()
        {
            //given
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();
            string ticket = standardParkingBoy.Park("car");
            string ticket2 = standardParkingBoy.Park("car");

            //when
            string fetchedCar = standardParkingBoy.Fetch(ticket);

            //then
            Assert.Equal("car", fetchedCar);
            Assert.Throws<UnvalidTicketException>(() => standardParkingBoy.Fetch(ticket));
            Assert.Throws<UnvalidTicketException>(() => standardParkingBoy.Fetch(null));
            Assert.Throws<UnvalidTicketException>(() => standardParkingBoy.Fetch("x"));
        }
    }
}
