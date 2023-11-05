using ParkingLot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ParkingLot.ParkingLot;
using Xunit;

namespace ParkingLotTest
{
    public class StandardParkingBoyTests
    {
        [Fact]
        public void Get_ticket_Sequentially_when_parkCar_by_parkingBoy()
        {
            // Given
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car1 = new Car();
            var car2 = new Car();

            //When
            var ticket1 = parkingBoy.ParkCar(car1);
            var ticket2 = parkingBoy.ParkCar(car2);

            //Then
            Assert.NotNull(ticket1);
            Assert.NotNull(ticket2);
            Assert.Throws<ParkingLotNoCapacityException>(() => parkingBoy.ParkCar(new Car()));
        }

        [Fact]
        public void Get_ticket_when_first_parkingLot_is_full_by_parkingBoy()
        {
            // Given
            var parkingLot1 = new ParkingLot.ParkingLot(0);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();

            //When
            var ticket = parkingBoy.ParkCar(car);

            //Then
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Get_correct_cars_when_fetch_car_with_valid_tickets_by_parkingBoy()
        {
            // Given
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car1 = new Car();
            var car2 = new Car();
            var ticket1 = parkingBoy.ParkCar(car1);
            var ticket2 = parkingBoy.ParkCar(car2);

            //When
            var fetchedCar1 = parkingBoy.Fetch(ticket1);
            var fetchedCar2 = parkingBoy.Fetch(ticket2);

            //Then
            Assert.Equal(car1, fetchedCar1);
            Assert.Equal(car2, fetchedCar2);
        }

        [Fact]
        public void Get_exception_when_fetch_car_with_wrong_ticket_by_parkingBoy()
        {
            // Given
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });

            //When
            var wrongTicket = new Ticket();
            var exception = Assert.Throws<InvalidTicketException>(() => parkingBoy.Fetch(wrongTicket));

            //Then
            Assert.Equal("Invalid parking ticket.", exception.Message);
        }

        [Fact]
        public void Get_exception_when_fetch_car_with_used_ticket_by_parkingBoy()
        {
            // Given
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            var car = new Car();
            var ticket = parkingBoy.ParkCar(car);

            //When
            parkingBoy.Fetch(ticket);
            var exception = Assert.Throws<InvalidTicketException>(() => parkingBoy.Fetch(ticket));

            //Then
            Assert.Equal("Invalid parking ticket.", exception.Message);
        }

        [Fact]
        public void Get_exception_when_parkingLot_is_full()
        {
            // Given
            var parkingLot1 = new ParkingLot.ParkingLot(1);
            var parkingLot2 = new ParkingLot.ParkingLot(1);
            var parkingBoy = new ParkingBoy(new List<ParkingLot.ParkingLot> { parkingLot1, parkingLot2 });
            parkingBoy.ParkCar(new Car());
            parkingBoy.ParkCar(new Car());

            //When && Then
            Assert.Throws<ParkingLotNoCapacityException>(() => parkingBoy.ParkCar(new Car()));
        }
    }
}
