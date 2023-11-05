namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit;
    using Xunit.Sdk;

    public class SmartParkingBoyTest
    {
        [Theory]
        [InlineData("car")]
        public void Should_return_a_ticket_when_park_given_a_smart_boy_with_a_car(string car)
        {
            //given
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy();

            //when
            string ticket = smartParkingBoy.Park(car);

            //then
            Assert.Equal("-car", ticket);
        }

        [Fact]
        public void Should_return_correct_car_when_fetch_given_a_smart_boy_with_a_ticket()
        {
            //given
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy();

            //when
            string ticket = smartParkingBoy.Park("car1");
            string ticket2 = smartParkingBoy.Park("car2");

            //then
            Assert.Equal("-car1", ticket);
            Assert.Equal("-car2", ticket2);
        }

        [Theory]
        [InlineData("x")]
        [InlineData(null)]
        public void Should_throw_exception_when_fetch_given_a_smart_boy_with_unvalid_ticket(string unvalidTicket)
        {
            //given
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy();

            //when
            smartParkingBoy.Park("car");

            //then
            Assert.Throws<UnvalidTicketException>(() => smartParkingBoy.Fetch(unvalidTicket));
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_a_smart_boy_with_a_used_ticket()
        {
            //given
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy();

            //when
            string ticket = smartParkingBoy.Park("car");
            string fetchedCar = smartParkingBoy.Fetch(ticket);

            //then
            Assert.Throws<UnvalidTicketException>(() => smartParkingBoy.Fetch(ticket));
        }

        [Fact]
        public void Should_throw_exception_when_park_given_a_smart_boy_with_a_full_parking_lot()
        {
            //given
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy();

            //when
            //the default positions in a new parking lot is 10
            int defalutPositions = 10;
            for (int i = 0; i < defalutPositions; i++)
            {
                smartParkingBoy.Park($"car{i}");
            }

            //then
            Assert.Throws<NoPositionException>(() => smartParkingBoy.Park($"car{defalutPositions}"));
        }

        [Fact]
        public void Should_park_car_in_lot_with_most_positions_available_when_park_given_a_smart_boy()
        {
            //given
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(new ParkingLot(2));
            parkingLots.Add(new ParkingLot(3));
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);

            //when
            smartParkingBoy.Park("car1");

            //then
            Assert.Equal(" | car1", smartParkingBoy.ShowAllCars());

            //and when
            smartParkingBoy.Park("car2");
            smartParkingBoy.Park("car3");

            //and then
            Assert.Equal("car2 | car1 car3", smartParkingBoy.ShowAllCars());
        }

        [Fact]
        public void Should_return_correct_car_when_fetch_cars_from_different_lots_given_a_smart_boy()
        {
            //given
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(new ParkingLot(2));
            parkingLots.Add(new ParkingLot(3));
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);

            //when
            string ticket1 = smartParkingBoy.Park("car1");
            string ticket2 = smartParkingBoy.Park("car2");

            //then
            Assert.Equal("car1", smartParkingBoy.Fetch(ticket1));
            Assert.Equal("car2", smartParkingBoy.Fetch(ticket2));
        }
    }
}
