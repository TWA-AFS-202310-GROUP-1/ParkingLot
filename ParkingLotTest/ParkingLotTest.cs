using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace ParkingLotTest
{
    public class ParkingLotTest
    {
        [Fact]
        public void Should_get_the_same_car_when_fetch_car_by_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = parkingLot.Park("car");
            string car = parkingLot.Fetch(ticket);
            Assert.Equal("car", car);
        }

        [Fact]
        public void Should_get_correct_car_when_fetch_car_with_corresponding_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");
            string ticket2 = parkingLot.Park("car2");

            string car1 = parkingLot.Fetch(ticket1);
            string car2 = parkingLot.Fetch(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_fetch_no_car_when_provide_no_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = string.Empty;
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_fetch_no_car_when_provide_wrong_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket = "T-c";

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_fetch_no_car_when_use_old_ticket()
        {
            ParkingLot parkingLot = new ParkingLot();
            string ticket1 = parkingLot.Park("car1");

            string car1 = parkingLot.Fetch(ticket1);
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Fetch(ticket1));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_have_no_ticket_when_prakingplot_is_full()
        {
            ParkingLot parkingLot = new ParkingLot();

            for (int i = 0; i < 10; i++)
            {
                parkingLot.Park("car" + i);
            }

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Park("newcar"));
            Assert.Equal("No available position.", wrongTicketException.Message);
        }
    }
}
