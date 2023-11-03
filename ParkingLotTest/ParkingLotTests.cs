namespace ParkingLotTest
{
    using ParkingLot;
    using Xunit;

    public class ParkingLotTests
    {
        [Fact]
        public void Get_Ticker_When_ParkingLotHasSpace_ReturnsTicket()
        {
            // Given
            ParkingLot parkingLot = new ParkingLot();
            string car = "ABC123"; // Car identifier
            string ticket; // Parking ticket

            // When
            ticket = parkingLot.ParkCar(car);

            // Then
            Assert.NotNull(ticket);
            Assert.NotEmpty(ticket);
        }
    }
}
