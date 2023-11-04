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
        public void Should_have_no_ticket_when_parkinglot_is_full()
        {
            ParkingLot parkingLot = new ParkingLot();

            for (int i = 0; i < 10; i++)
            {
                parkingLot.Park("car" + i);
            }

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => parkingLot.Park("newcar"));
            Assert.Equal("No available position.", wrongTicketException.Message);
        }

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

        [Fact]
        public void Should_park_into_first_parkinglot_when_first_parkinglot_is_not_full()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLot1, parkingLot2);

            string ticket = standardParkingBoy.StandardPark("newcar");

            Assert.Equal("T-newcar-in-parkingLot1", ticket);
        }

        [Fact]
        public void Should_park_into_second_parkinglot_when_first_parkinglot_is_full()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLot1, parkingLot2);

            for (int i = 0; i < 10; i++)
            {
                standardParkingBoy.StandardPark("car" + i);
            }

            string ticket = standardParkingBoy.StandardPark("newcar");

            Assert.Equal("T-newcar-in-parkingLot2", ticket);
        }

        [Fact]
        public void Should_fetch_right_ticket_when_different_parkinglot_has_cars()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLot1, parkingLot2);

            string ticket1 = standardParkingBoy.StandardPark("car1");
            for (int i = 2; i < 11; i++)
            {
                standardParkingBoy.StandardPark("car" + i);
            }

            string ticket2 = standardParkingBoy.StandardPark("car2");
            string nowticket1 = standardParkingBoy.StandardFetch(ticket1);
            string nowticket2 = standardParkingBoy.StandardFetch(ticket2);
            Assert.Equal("car1", nowticket1);
            Assert.Equal("car2", nowticket2);
        }

        [Fact]
        public void Should_fetch_wrong_message_by_standard_parkingboy_when_provide_wrong_ticket()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLot1, parkingLot2);
            string ticket = "T-c";

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => standardParkingBoy.StandardFetch(ticket));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }

        [Fact]
        public void Should_fetch_wrong_message_by_standard_parkingboy_when_use_old_ticket()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLot1, parkingLot2);
            string ticket1 = standardParkingBoy.StandardPark("car1");

            string car1 = standardParkingBoy.StandardFetch(ticket1);
            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => standardParkingBoy.StandardFetch(ticket1));
            Assert.Equal("Unrecognized parking ticket.", wrongTicketException.Message);
        }
    }
}
