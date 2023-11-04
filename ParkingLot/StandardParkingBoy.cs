using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public class StandardParkingBoy
    {
        private ParkingLot parkingLot1;
        private ParkingLot parkingLot2;
        public StandardParkingBoy(ParkingLot lot1, ParkingLot lot2)
        {
            this.parkingLot1 = lot1;
            this.parkingLot2 = lot2;
        }

        public string StandardPark(string car)
        {
            try
            {
                return parkingLot1.Park(car) + "-in-parkingLot1";
            }
            catch (WrongTicketException e)
            {
                return parkingLot2.Park(car) + "-in-parkingLot2";
            }
        }

/*        public string StandardFetch(string ticket) 
        {
            
        }*/
    }
}
