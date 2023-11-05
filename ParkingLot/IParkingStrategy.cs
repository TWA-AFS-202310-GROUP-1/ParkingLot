using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day5
{
    public interface IParkingStrategy
    {
        public string Park(string car, Dictionary<string, ParkingLot> id2parkingLot);
    }
}
