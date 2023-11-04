using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyTest
    {
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

        [Fact]
        public void Should_have_no_ticket_by_standard_parkingboy_when_parkinglot_is_full()
        {
            ParkingLot parkingLot1 = new ParkingLot();
            ParkingLot parkingLot2 = new ParkingLot();
            StandardParkingBoy standardParkingBoy = new StandardParkingBoy(parkingLot1, parkingLot2);

            for (int i = 0; i < 20; i++)
            {
                standardParkingBoy.StandardPark("car" + i);
            }

            WrongTicketException wrongTicketException = Assert.Throws<WrongTicketException>(() => standardParkingBoy.StandardPark("newcar"));
            Assert.Equal("No available position.", wrongTicketException.Message);
        }
    }
}
