namespace ParkingLotTest
{
    using ParkingLot;
    using System.Collections.Generic;
    using System.Reflection;
    using Xunit;
    using Xunit.Sdk;

    public class SmartParkingBoyTest
    {
        [Fact]
        public void Should_be_in_correct_sequence_when_park_cars_given_a_smart_parking_boy()
        {
            //given
            List<ParkingLot> parkingLots = new List<ParkingLot>();
            parkingLots.Add(new ParkingLot(1));
            parkingLots.Add(new ParkingLot(1));
            parkingLots.Add(new ParkingLot(2));
            SmartParkingBoy smartParkingBoy = new SmartParkingBoy(parkingLots);

            //when
            smartParkingBoy.Park("car1");

            //then
            Assert.Equal(" |  | car1", smartParkingBoy.ShowAllCars());

            //and when
            smartParkingBoy.Park("car2");
            smartParkingBoy.Park("car3");
            smartParkingBoy.Park("car4");

            //then
            Assert.Equal("car2 | car3 | car1 car4", smartParkingBoy.ShowAllCars());
            Assert.Throws<NoPositionException>(() => smartParkingBoy.Park("car5"));
            Assert.Throws<UnvalidTicketException>(() => smartParkingBoy.Fetch("x"));
            Assert.Throws<UnvalidTicketException>(() => smartParkingBoy.Fetch(null));

            Assert.Equal("car1", smartParkingBoy.Fetch("-car1"));
            Assert.Throws<UnvalidTicketException>(() => smartParkingBoy.Fetch("-car1"));

            //and when
            smartParkingBoy.Park("car5");
            Assert.Equal("car2 | car3 | car5 car4", smartParkingBoy.ShowAllCars());
            Assert.Throws<NoPositionException>(() => smartParkingBoy.Park("car6"));
        }
    }
}
