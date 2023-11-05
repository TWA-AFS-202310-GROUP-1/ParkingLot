namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit;
    using Xunit.Sdk;

    public class StandardParkingBoyTest
    {
        [Theory]
        [InlineData("car")]
        public void Should_return_a_ticket_when_park_given_a_standard_boy_with_a_car(string car)
        {
            //given
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();

            //when
            string ticket = standardParkingBoy.Park(car);

            //then
            Assert.Equal("-car", ticket);
        }

        [Fact]
        public void Should_return_correct_car_when_fetch_given_a_standard_boy_with_a_ticket()
        {
            //given
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();
            string ticket = standardParkingBoy.Park("car");
            string ticket2 = standardParkingBoy.Park("car2");

            //when
            string fetchedCar = standardParkingBoy.Fetch(ticket);
            string fetchedCar2 = standardParkingBoy.Fetch(ticket2);

            //then
            Assert.Equal("car", fetchedCar);
            Assert.Equal("car2", fetchedCar2);
        }

        [Theory]
        [InlineData("x")]
        [InlineData(null)]
        public void Should_throw_exception_when_fetch_given_a_standard_boy_with_unvalid_ticket(string unvalidTicket)
        {
            //given
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();

            //when
            standardParkingBoy.Park("car");

            //then
            Assert.Throws<UnvalidTicketException>(() => standardParkingBoy.Fetch(unvalidTicket));
        }

        [Fact]
        public void Should_throw_exception_when_park_given_a_standard_boy_with_a_full_parking_lot()
        {
            //given
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();

            //when
            //the default positions in a new parking lot is 10
            int defalutPositions = 10;
            for (int i = 0; i < defalutPositions; i++)
            {
                standardParkingBoy.Park($"car{i}");
            }

            //then
            Assert.Throws<NoPositionException>(() => standardParkingBoy.Park($"car{defalutPositions}"));
        }

        [Fact]
        public void Should_throw_exception_when_fetch_given_a_standard_boy_with_a_used_ticket()
        {
            //given
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy();

            //when
            string ticket = standardParkingBoy.Park("car");
            string fetchedCar = standardParkingBoy.Fetch(ticket);

            //then
            Assert.Throws<UnvalidTicketException>(() => standardParkingBoy.Fetch(ticket));
        }

        [Fact]
        public void Should_park_car_in_first_lot_when_both_lots_are_available_given_a_standard_boy()
        {
            //given
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(new ParkingLot(2));
            parkingLots.Add(new ParkingLot(2));
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);

            //when
            standardParkingBoy.Park("car");

            //then
            Assert.Equal("car | ", standardParkingBoy.ShowAllCars());
        }

        [Fact]
        public void Should_park_car_in_second_lot_when_first_lot_is_not_available_given_a_standard_boy()
        {
            //given
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(new ParkingLot(2));
            parkingLots.Add(new ParkingLot(2));
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);

            //when
            standardParkingBoy.Park("car1");
            standardParkingBoy.Park("car2");
            standardParkingBoy.Park("car3");

            //then
            Assert.Equal("car1 car2 | car3", standardParkingBoy.ShowAllCars());

            //and when
            standardParkingBoy.Fetch("-car2");
            standardParkingBoy.Park("car4");

            //and then
            Assert.Equal("car1 car4 | car3", standardParkingBoy.ShowAllCars());
        }

        [Fact]
        public void Should_return_correct_car_when_fetch_cars_from_different_lots_given_a_standard_boy()
        {
            //given
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(new ParkingLot(2));
            parkingLots.Add(new ParkingLot(2));
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);

            //when
            string ticket1 = standardParkingBoy.Park("car1");
            string ticket2 = standardParkingBoy.Park("car2");
            string ticket3 = standardParkingBoy.Park("car3");

            //then
            Assert.Equal("car1", standardParkingBoy.Fetch(ticket1));
            Assert.Equal("car3", standardParkingBoy.Fetch(ticket3));
        }
    }
}
