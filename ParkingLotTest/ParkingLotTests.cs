using ParkingLot;
using Xunit;
using static ParkingLot.ParkingLot;

namespace ParkingLotTest
{
    public class ParkingLotTests
    {
        [Fact]
        public void Get_ticket_when_parkingLot_has_capacity_given_parkingLot()
        {
            // Given
            var parkingLot = new ParkingLot.ParkingLot(10);
            var car = new Car();

            // When
            var ticket = parkingLot.ParkCar(car);

            // Then
            Assert.NotNull(ticket);
        }

        [Fact]
        public void Get_car_when_fetch_car_with_valid_ticket()
        {
            // Given
            var parkingLot = new ParkingLot.ParkingLot(10);
            var car = new Car();
            var ticket = parkingLot.ParkCar(car);

            // When
            var fetchedCar = parkingLot.Fetch(ticket);

            // Then
            Assert.Equal(car, fetchedCar);
        }

        [Fact]
        public void Get_car_twice_when_fetch_car_with_valid_ticket()
        {
            // Given
            var parkingLot = new ParkingLot.ParkingLot(10);
            var car1 = new Car();
            var car2 = new Car();
            var ticket1 = parkingLot.ParkCar(car1);
            var ticket2 = parkingLot.ParkCar(car2);

            // When
            var fetchedCar1 = parkingLot.Fetch(ticket1);
            var fetchedCar2 = parkingLot.Fetch(ticket2);

            // Then
            Assert.Equal(car1, fetchedCar1);
            Assert.Equal(car2, fetchedCar2);
        }

        [Fact]
        public void Get_exception_when_fetch_car_given_wrong_ticket()
        {
            // Given
            var parkingLot = new ParkingLot.ParkingLot(10);
            var car = new Car();
            parkingLot.ParkCar(car);
            var wrongTicket = new Ticket();

            // When
            var exception = Assert.Throws<InvalidTicketException>(() => parkingLot.Fetch(wrongTicket));

            // Then
            Assert.Equal("Invalid parking ticket.", exception.Message);
        }

        [Fact]
        public void Get_exception_when_fetch_car_given_used_ticket()
        {
            // Given
            var parkingLot = new ParkingLot.ParkingLot(10);
            var car = new Car();
            var ticket = parkingLot.ParkCar(car);
            parkingLot.Fetch(ticket);

            // When
            var exception = Assert.Throws<InvalidTicketException>(() => parkingLot.Fetch(ticket));

            // Then
            Assert.Equal("Invalid parking ticket.", exception.Message);
        }

        [Fact]
        public void Get_exception_when_parkingLot_is_full()
        {
            // Given
            var parkingLot = new ParkingLot.ParkingLot(1);
            var car1 = new Car();
            var car2 = new Car();
            parkingLot.ParkCar(car1);

            // When
            var exception = Assert.Throws<ParkingLotNoCapacityException>(() => parkingLot.ParkCar(car2));

            // Then
            Assert.Equal("No capacity for car now.", exception.Message);
        }
    }
}
