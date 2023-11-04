using Day5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParkingLot2
{
    public interface IParkingStrategy
    {
        string Park(string car, List<ParkingLot> parkingLots);
        string Fetch(string ticket, List<ParkingLot> parkingLots);
    }

    public class StandardParkingStrategy : IParkingStrategy
    {
        public string Park(string car, List<ParkingLot> parkingLots)
        {
            try
            {
                return parkingLots[0].Park(car) + "-in-parkingLot1";
            }
            catch (WrongTicketException e)
            {
                return parkingLots[1].Park(car) + "-in-parkingLot2";
            }
        }

        public string Fetch(string ticket, List<ParkingLot> parkingLots)
        {
            string pattern = @"^T-[a-zA-Z0-9]+-in-parkingLot[0-9]+$"; // 正则表达式模式

            if (!Regex.IsMatch(ticket, pattern))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            string[] ticketParts = ticket.Split('-');
            string nowTicket = $"{ticketParts[0]}-{ticketParts[1]}";
            if (ticketParts[3] == "parkingLot1")
            {
                return parkingLots[0].Fetch(nowTicket);
            }
            else if (ticketParts[3] == "parkingLot2")
            {
                return parkingLots[1].Fetch(nowTicket);
            }
            else
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }
        }
    }

    public class SmartParkingStrategy : IParkingStrategy
    {
        public string Park(string car, List<ParkingLot> parkingLots)
        {
            int availableSpots1 = parkingLots[0].AvailableSpots();
            int availableSpots2 = parkingLots[1].AvailableSpots();

            if (availableSpots1 >= availableSpots2)
            {
                return parkingLots[0].Park(car) + "-in-parkingLot1";
            }
            else if (availableSpots2 > availableSpots1)
            {
                return parkingLots[1].Park(car) + "-in-parkingLot2";
            }

            return " ";
        }

        public string Fetch(string ticket, List<ParkingLot> parkingLots)
        {
            string pattern = @"^T-[a-zA-Z0-9]+-in-parkingLot[0-9]+$"; // 正则表达式模式

            if (!Regex.IsMatch(ticket, pattern))
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }

            string[] ticketParts = ticket.Split('-');
            string nowTicket = $"{ticketParts[0]}-{ticketParts[1]}";
            if (ticketParts[3] == "parkingLot1")
            {
                return parkingLots[0].Fetch(nowTicket);
            }
            else if (ticketParts[3] == "parkingLot2")
            {
                return parkingLots[1].Fetch(nowTicket);
            }
            else
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }
        }
    }

    public class ParkingLot
    {
        private string car;
        private Dictionary<string, string> ticket2car = new Dictionary<string, string>();
        public string Fetch(string ticket)
        {
            if (ticket == null)
            {
                return null;
            }

            if (ticket2car.ContainsKey(ticket))
            {
                string nowTicket = ticket2car[ticket];
                ticket2car.Remove(ticket);
                return nowTicket;
            }
            else
            {
                throw new WrongTicketException("Unrecognized parking ticket.");
            }
        }

        public int AvailableSpots()
        {
            return 10 - ticket2car.Count;
        }

        public string Park(string car)
        {
            if (ticket2car.Count() < 10)
            {
                this.car = car;
                string ticket = "T-" + car;
                ticket2car.Add(ticket, car);
                return ticket;
            }
            else
            {
                throw new WrongTicketException("No available position.");
            }
        }
    }

    public class ParkingBoy
    {
        private IParkingStrategy parkingStrategy;
        private List<ParkingLot> parkingLots;

        public ParkingBoy(IParkingStrategy strategy, List<ParkingLot> lots)
        {
            this.parkingStrategy = strategy;
            this.parkingLots = lots;
        }

        public string Park(string car)
        {
            return parkingStrategy.Park(car, parkingLots);
        }

        public string Fetch(string ticket)
        {
            return parkingStrategy.Fetch(ticket, parkingLots);
        }
    }
}
