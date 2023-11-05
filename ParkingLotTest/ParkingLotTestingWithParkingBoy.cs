using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLotSystem;

namespace ParkingLotTest
{
    public class ParkingLotTestingWithParkingBoy
    {
        [Fact]
        public void Should_Return_Ticket_When_Park_Car()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);

            var ticket = parkingBoy.Park("Car1");

            Assert.NotNull(ticket);
        }

        [Fact]
        public void Should_Return_Car_When_Fetch_With_Valid_Ticket()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var ticket = parkingBoy.Park("Car1");

            var car = parkingBoy.Fetch(ticket);

            Assert.Equal("Car1", car);
        }

        [Fact]
        public void Should_return_right_car_with_each_ticket_when_fetch_twice()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var ticket1 = parkingBoy.Park("Car1");
            var ticket2 = parkingBoy.Park("Car2");

            var car1 = parkingBoy.Fetch(ticket1);
            var car2 = parkingBoy.Fetch(ticket2);

            Assert.Equal("Car1", car1);
            Assert.Equal("Car2", car2);
        }

        [Fact]
        public void Should_Throw_Exception_When_Fetch_With_Invalid_Ticket()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            parkingBoy.Park("Car1");

            var exception = Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch("invalid_ticket"));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_return_nothing_with_error_message_when_fetch_with_used_ticket()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            var ticket = parkingBoy.Park("Car1");
            parkingBoy.Fetch(ticket); 

            var exception = Assert.Throws<WrongTicketException>(() => parkingBoy.Fetch(ticket));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Park_Car_And_Lot_Is_Full()
        {
            var parkingLot = new ParkingLot();
            var parkingBoy = new ParkingBoy(parkingLot);
            for (int i=0; i < 10; i++) 
            {
                parkingBoy.Park("Car" + i);
            }           

            var exception = Assert.Throws<NoPositionException>(() => parkingBoy.Park("Car10"));

            Assert.Equal("No available position.", exception.Message);
        }
    }
}
