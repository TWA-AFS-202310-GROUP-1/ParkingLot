using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class ParkingBoyTest
    {
        [Fact]
        public void Should_get_the_parking_ticket_when_parkingboy_fetch_car_by_ticket()
        {
            ParkingBoy parkingBoy = new ParkingBoy();
            string ticket = parkingBoy.ParkByParkingBoy("car");
            Assert.Equal("T-car", ticket);
        }

        [Fact]
        public void Should_get_the_same_car_by_parkingboy_when_fetch_car_by_ticket()
        {
            ParkingBoy parkingBoy = new ParkingBoy();
            string ticket = parkingBoy.ParkByParkingBoy("car");
            string car = parkingBoy.FetchByParkingBoy(ticket);
            Assert.Equal("car", car);
        }

        [Fact]
        public void Should_get_correct_car_by_parkingboy_when_fetch_car_with_corresponding_ticket()
        {
            ParkingBoy parkingBoy = new ParkingBoy();
            string ticket1 = parkingBoy.ParkByParkingBoy("car1");
            string ticket2 = parkingBoy.ParkByParkingBoy("car2");

            string car1 = parkingBoy.FetchByParkingBoy(ticket1);
            string car2 = parkingBoy.FetchByParkingBoy(ticket2);

            Assert.Equal("car1", car1);
            Assert.Equal("car2", car2);
        }

        [Fact]
        public void Should_fetch_no_car_by_parkingboy_when_provide_wrong_ticket()
        {
            ParkingBoy parkingBoy = new ParkingBoy();
            string ticket = "T-c";

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.FetchByParkingBoy(ticket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_fetch_no_car_by_parkingboy_when_use_old_ticket()
        {
            ParkingBoy parkingBoy = new ParkingBoy();
            string ticket1 = parkingBoy.ParkByParkingBoy("car1");

            string car1 = parkingBoy.FetchByParkingBoy(ticket1);
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.FetchByParkingBoy(ticket1));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_have_no_ticket_by_parkingboy_when_parkinglot_is_full()
        {
            ParkingBoy parkingBoy = new ParkingBoy();

            for (int i = 0; i < 10; i++)
            {
                parkingBoy.ParkByParkingBoy("car" + i);
            }

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingBoy.ParkByParkingBoy("newcar"));
            Assert.Equal("No available position.", wrongTicketException.Message);
        }
    }
}
