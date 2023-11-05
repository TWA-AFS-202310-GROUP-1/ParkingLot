using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLotSystem;

namespace ParkingLotTest
{
    public class ParkingLotTestWithParkingBoyMultipleLots
    {
        [Fact]
        public void Should_Park_In_First_Lot_When_Both_Are_Empty()
        {
            var parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            var ParkingBoyMultipleLots = new ParkingBoyMultipleLots(parkingLots);

            var ticket = ParkingBoyMultipleLots.Park("Car1");

            Assert.Equal("Car1", ParkingBoyMultipleLots.ParkingLots[0].Fetch(ticket));
            var exception = Assert.Throws<WrongTicketException>(() => ParkingBoyMultipleLots.ParkingLots[1].Fetch(ticket));
        }

        [Fact]
        public void Should_Park_In_Second_Lot_When_First_Is_Full()
        {
            var fullParkingLot = new ParkingLot();
            for(int i = 0; i < 10; i++)
            {
                fullParkingLot.Park("Car" + i);
            }
            var parkingLots = new List<ParkingLot> { fullParkingLot, new ParkingLot() };
            var ParkingBoyMultipleLots = new ParkingBoyMultipleLots(parkingLots);

            var ticket = ParkingBoyMultipleLots.Park("Car10");

            var exception = Assert.Throws<WrongTicketException>(() => ParkingBoyMultipleLots.ParkingLots[0].Fetch(ticket));
            Assert.Equal("Car10", ParkingBoyMultipleLots.ParkingLots[1].Fetch(ticket));
        }

        [Fact]
        public void Should_Fetch_Correct_Cars_From_Multiple_Lots()
        {
            var parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            var ParkingBoyMultipleLots = new ParkingBoyMultipleLots(parkingLots);
            var ticket1 = ParkingBoyMultipleLots.Park("Car1");
            var ticket2 = ParkingBoyMultipleLots.Park("Car2");

            var car1 = ParkingBoyMultipleLots.Fetch(ticket1);
            var car2 = ParkingBoyMultipleLots.Fetch(ticket2);

            Assert.Equal("Car1", car1);
            Assert.Equal("Car2", car2);
        }

        [Fact]
        public void Should_Throw_Exception_When_Unrecognized_Ticket()
        {
            var parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            var ParkingBoyMultipleLots = new ParkingBoyMultipleLots(parkingLots);

            var exception = Assert.Throws<WrongTicketException>(() => ParkingBoyMultipleLots.Fetch("wrongticket"));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_Ticket_Is_Used()
        {
            var parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            var ParkingBoyMultipleLots = new ParkingBoyMultipleLots(parkingLots);
            var ticket = ParkingBoyMultipleLots.Park("Car1");
            ParkingBoyMultipleLots.Fetch(ticket); 

            var exception = Assert.Throws<WrongTicketException>(() => ParkingBoyMultipleLots.Fetch(ticket));

            Assert.Equal("Unrecognized parking ticket.", exception.Message);
        }

        [Fact]
        public void Should_Throw_Exception_When_All_Lots_Are_Full()
        {
            var parkingLots = new List<ParkingLot> { new ParkingLot(), new ParkingLot() };
            var ParkingBoyMultipleLots = new ParkingBoyMultipleLots(parkingLots);
            for(int i = 0; i < 20; i++)
            {
                ParkingBoyMultipleLots.Park("car" +  i);
            }

            var exception = Assert.Throws<NoPositionException>(() => ParkingBoyMultipleLots.Park("Car20"));

            Assert.Equal("No available position.", exception.Message);
        }
    }
}
