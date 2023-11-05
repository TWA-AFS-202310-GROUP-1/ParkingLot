using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ParkingLotSystem;
using System.Runtime.ConstrainedExecution;

namespace ParkingLotTest
{
    public class ParkingLotTestingWithSmartParkingBoyMultipleLots
    {
        [Fact]
        public void Should_Park_In_Lot_With_Most_Spaces_When_SmartParkingBoy_Parks_Car()
        {
            var lotWithMoreSpace = new ParkingLot();
            var lotWithLessSpace = new ParkingLot();
            for(int i = 0; i < 7; i++)
            {
                lotWithLessSpace.Park("car" + i + "less");
            }
            for(int i = 0; i < 5; i++)
            {
                lotWithMoreSpace.Park("car" + i + "more");
            }
            var smartParkingBoy = new SmartParkingBoyMultipleLots(new List<ParkingLot> { lotWithLessSpace , lotWithMoreSpace });
            var ticket = smartParkingBoy.Park("new car");

            var exception = Assert.Throws<WrongTicketException>(() => smartParkingBoy.ParkingLots[0].Fetch(ticket));
            Assert.Equal("new car", lotWithMoreSpace.Fetch(ticket)); 
        }

        [Fact]
        public void Should_ThrowException_When_All_Lots_Full()
        {
            var lot1 = new ParkingLot();
            var lot2 = new ParkingLot();
            var smartParkingBoy = new SmartParkingBoyMultipleLots(new List<ParkingLot> { lot1, lot2 });
            for (int i = 0; i < 20; i++)
            {
                smartParkingBoy.Park("car" + i);
            }

            Assert.Throws<NoPositionException>(() => smartParkingBoy.Park("new car"));
        }


        [Fact]
        public void Should_Park_In_Available_Lot_When_One_Lot_Is_Full()
        {
            var fullLot = new ParkingLot();
            var availableLot = new ParkingLot();
            for(int i = 0;i < 10; i++)
            {
                fullLot.Park("car" + i);
            }
            var smartParkingBoy = new SmartParkingBoyMultipleLots(new List<ParkingLot> { fullLot, availableLot });

            var ticket = smartParkingBoy.Park("new car");

            var exception = Assert.Throws<WrongTicketException>(() => smartParkingBoy.ParkingLots[0].Fetch(ticket));
            Assert.Equal("new car", smartParkingBoy.ParkingLots[1].Fetch(ticket));
        }

        [Fact]
        public void Should_Park_In_First_Lot_When_Lots_Have_Equal_Space()
        {
            var lot1 = new ParkingLot();
            var lot2 = new ParkingLot();
            var smartParkingBoy = new SmartParkingBoyMultipleLots(new List<ParkingLot> { lot1, lot2 });

            var ticket = smartParkingBoy.Park("new car");

            Assert.Equal("new car", smartParkingBoy.ParkingLots[0].Fetch(ticket));
            var exception = Assert.Throws<WrongTicketException>(() => smartParkingBoy.ParkingLots[1].Fetch(ticket));
            
        }

    }
}
