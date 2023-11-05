namespace ParkingLotTest
{
    using Microsoft.VisualBasic;
    using ParkingLotSystem;
    using ParkingLotSystem.Strategy;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Sockets;
    using Xunit;


    public class StrategyTest
    {
        [Fact]
        public void Should_Park_Correct_When_Use_Standard_Strategy()
        {
            var lotWithMoreSpace = new ParkingLot();
            var lotWithLessSpace = new ParkingLot();
            for (int i = 0; i < 7; i++)
            {
                lotWithLessSpace.Park("car" + i + "less");
            }
            for (int i = 0; i < 5; i++)
            {
                lotWithMoreSpace.Park("car" + i + "more");
            }
            var parkingBoy = new ParkingBoyV2(new List<ParkingLot> { lotWithLessSpace, lotWithMoreSpace  }, new StandardParkingStrategy());

            var ticket = parkingBoy.Park("new car");

            var exception = Assert.Throws<WrongTicketException>(() => parkingBoy.ParkingLots[1].Fetch(ticket));
            Assert.Equal("new car", parkingBoy.ParkingLots[0].Fetch(ticket));
        }

        [Fact]
        public void Should_Park_Correct_When_Use_Smart_Strategy()
        {
            var lotWithMoreSpace = new ParkingLot();
            var lotWithLessSpace = new ParkingLot();
            for (int i = 0; i < 7; i++)
            {
                lotWithLessSpace.Park("car" + i + "less");
            }
            for (int i = 0; i < 5; i++)
            {
                lotWithMoreSpace.Park("car" + i + "more");
            }
            var parkingBoy = new ParkingBoyV2(new List<ParkingLot> { lotWithLessSpace, lotWithMoreSpace }, new SmartParkingStrategy());

            var ticket = parkingBoy.Park("new car");

            var exception = Assert.Throws<WrongTicketException>(() => parkingBoy.ParkingLots[0].Fetch(ticket));
            Assert.Equal("new car", parkingBoy.ParkingLots[1].Fetch(ticket));
        }
    }
}
