namespace ParkingLotTest
{
    using ParkingLotSystem;
    using System.IO;
    using System.Net.Sockets;
    using Xunit;

    public class ParkingLotTest
    {
        [Fact]
        public void Should_return_ticket_when_park_car()
        {
            var parkingLot = new ParkingLot();
            var ticket = parkingLot.Park("Car1");
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_return_correct_car_when_fetch_car_given_a_ticket()
        {
            var parkingLot = new ParkingLot();
            var ticket = parkingLot.Park("Car1");
            string car = parkingLot.Fetch(ticket);
            Assert.Equal("Car1", car);
        }

        [Fact]
        public void Should_return_right_car_when_fetch_two_cars()
        {
            var parkingLot = new ParkingLot();
            var ticket1 = parkingLot.Park("Car1");
            var ticket2 = parkingLot.Park("Car2");
            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);
            Assert.Equal("Car1", car1);
            Assert.Equal("Car2", car2);
        }

        [Fact]
        public void Should_return_nothing_when_fetch_given_a_wrong_ticket()
        {
            var parkingLot = new ParkingLot();
            var ticket = parkingLot.Park("Car1");
            var wrongTicket = "wrongticket";
            string car = parkingLot.Fetch(wrongTicket);
            Assert.Null(car);

        }

        [Fact]
        public void Should_return_nothing_when_fetch_with_a_used_ticket()
        {
            var parkingLot = new ParkingLot();
            var ticket = parkingLot.Park("Car1");
            string car = parkingLot.Fetch(ticket);
            string carExpectednull = parkingLot.Fetch(ticket);
            Assert.Equal("Car1", car);
            Assert.Null(carExpectednull);
        }
    }
}
