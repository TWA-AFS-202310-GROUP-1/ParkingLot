namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit;
    using Xunit.Sdk;

    public class StandardParkingBoyTest
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

        [Fact]
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

        [Fact]
        public void Should_park_cars_in_sequence_when_parking_by_standard_boy_given_multiple_parking_lots()
        {
            //given
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            ParkingLot lot1 = new ParkingLot(2);
            ParkingLot lot2 = new ParkingLot(2);
            parkingLots.Add(lot1);
            parkingLots.Add(lot2);
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLots);

            //when
            for (int i = 1; i < 5; i++)
            {
                string tempTicket = standardParkingBoy.Park($"car{i}");
            }

            //then
            Assert.Equal("car1 car2 | car3 car4", standardParkingBoy.ShowAllCars());
            Assert.Throws<NoPositionException>(() => standardParkingBoy.Park("car5"));

            //and when
            string fetchedCar = standardParkingBoy.Fetch("-car2");
            string fetchedCar2 = standardParkingBoy.Fetch("-car3");
            string tempTicket1 = standardParkingBoy.Park("car5");
            string tempTicket2 = standardParkingBoy.Park("car6");

            //and then
            Assert.Equal("car1 car5 | car6 car4", standardParkingBoy.ShowAllCars());
            Assert.Throws<NoPositionException>(() => standardParkingBoy.Park("car7"));
        }
    }
}
