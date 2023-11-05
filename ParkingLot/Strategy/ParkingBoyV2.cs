using ParkingLotSystem.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLotSystem.Strategy
{
    public class ParkingBoyV2
    {
        private readonly List<ParkingLot> _parkingLots;
        public List<ParkingLot> ParkingLots { get => _parkingLots; }
        private readonly IParkingStrategy _parkingStrategy;

        public ParkingBoyV2(List<ParkingLot> parkingLots, IParkingStrategy parkingStrategy)
        {
            _parkingLots = parkingLots;
            _parkingStrategy = parkingStrategy;
        }

        public string Park(string car)
        {
            return _parkingStrategy.Park(_parkingLots, car);
        }

        public string Fetch(string ticket)
        {
            foreach (var parkingLot in _parkingLots)
            {
                try
                {
                    return parkingLot.Fetch(ticket);
                }
                catch (WrongTicketException)
                {
                    continue;
                }
            }

            throw new WrongTicketException("Unrecognized parking ticket.");
        }
    }
}
