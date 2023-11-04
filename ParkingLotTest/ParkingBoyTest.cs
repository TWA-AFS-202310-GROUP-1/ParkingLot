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
            string ticket2 = standardParkingBoy.Park("car2");

            //when
            string fetchedCar = standardParkingBoy.Fetch(ticket);
            string fetchedCar2 = standardParkingBoy.Fetch(ticket2);

            //then
            Assert.Throws<UnvalidTicketException>(() => standardParkingBoy.Fetch(null));
            Assert.Throws<UnvalidTicketException>(() => standardParkingBoy.Fetch("x"));
            Assert.Equal("car", fetchedCar);
            Assert.Equal("car2", fetchedCar2);
            Assert.Throws<UnvalidTicketException>(() => standardParkingBoy.Fetch(ticket));
        }

        public void Should_return_no_position_exception_when_park_car_by_parking_boy_given_a_full_parking_lot()
        {
            //given
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();

            //when
            for (int i = 0; i < 10; i++)
            {
                string tempTicket = standardParkingBoy.Park($"car{i}");
            }

            //then
            Assert.Throws<NoPositionException>(() => standardParkingBoy.Park("car10"));
        }
    }
}
