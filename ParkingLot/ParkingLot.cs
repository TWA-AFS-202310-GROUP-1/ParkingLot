using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotManagement
{
    public class ParkingLot
    {
        private string car;
        public string Fetch(string ticket)
        {
            return car;
        }

        public string Park(string car)
        {
            this.car = car;
            return "q";
        }
    }
}
