using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightFare
{
    public class Ticket
    {
        public string TicketId { get; set; }
        public string PassengerName { get; set; }
        public int Fare { get; set; }

        public Ticket(string ticketId, string passengerName, int fare)
        {
            TicketId = ticketId;
            PassengerName = passengerName;
            Fare = fare;
        }
    }

    public class InvalidFareException : Exception
    {
        public InvalidFareException(string message) : base(message) { }
    }

    public class DuplicateTicketException : Exception
    {
        public DuplicateTicketException(string message) : base(message) { }
    }

    public class TicketNotFoundException : Exception
    {
        public TicketNotFoundException(string message) : base(message) { }
    }

    public class FareManager
    {
        private SortedDictionary<int, List<Ticket>> tickets = new SortedDictionary<int, List<Ticket>>();

        public void AddTicket(Ticket ticket)
        {
            if (ticket.Fare <= 0)
                throw new InvalidFareException("Fare must be greater than zero.");

            foreach (var list in tickets.Values)
            {
                if (list.Any(t => t.TicketId == ticket.TicketId))
                    throw new DuplicateTicketException($"Ticket with ID {ticket.TicketId} already exists.");
            }

            if (!tickets.ContainsKey(ticket.Fare))
                tickets[ticket.Fare] = new List<Ticket>();
            tickets[ticket.Fare].Add(ticket);
        }

        public void UpdateFare(string ticketId, int newFare)
        {
            if (newFare <= 0)
                throw new InvalidFareException("Fare must be greater than zero.");

            Ticket target = null;
            int oldFare = -1;

            foreach (var pair in tickets)
            {
                var t = pair.Value.FirstOrDefault(x => x.TicketId == ticketId);
                if (t != null)
                {
                    target = t;
                    oldFare = pair.Key;
                    break;
                }
            }

            if (target == null)
                throw new TicketNotFoundException($"Ticket {ticketId} not found.");

            // Remove and Re-add
            tickets[oldFare].Remove(target);
            if (tickets[oldFare].Count == 0)
                tickets.Remove(oldFare);

            target.Fare = newFare;
            if (!tickets.ContainsKey(newFare))
                tickets[newFare] = new List<Ticket>();
            tickets[newFare].Add(target);
        }

        public List<Ticket> GetAllTickets()
        {
            List<Ticket> all = new List<Ticket>();
            foreach (var pair in tickets)
            {
                all.AddRange(pair.Value);
            }
            return all;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            FareManager manager = new FareManager();

            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1 -> Display Tickets");
                Console.WriteLine("2 -> Update Fare");
                Console.WriteLine("3 -> Add Ticket");
                Console.WriteLine("4 -> Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var list = manager.GetAllTickets();
                            if (list.Count == 0)
                                Console.WriteLine("No tickets found.");
                            else
                            {
                                foreach (var t in list)
                                    Console.WriteLine($"Details: {t.TicketId} {t.PassengerName} {t.Fare}");
                            }
                            break;

                        case "2":
                            Console.Write("Ticket ID: ");
                            string id = Console.ReadLine();
                            Console.Write("New Fare: ");
                            if (int.TryParse(Console.ReadLine(), out int fare))
                            {
                                manager.UpdateFare(id, fare);
                                Console.WriteLine("Fare updated successfully.");
                            }
                            break;

                        case "3":
                            Console.WriteLine("Enter details (ID Name Fare):");
                            string[] p = Console.ReadLine().Split(' ');
                            if (p.Length == 3)
                            {
                                manager.AddTicket(new Ticket(p[0], p[1], int.Parse(p[2])));
                                Console.WriteLine("Ticket added successfully.");
                            }
                            break;

                        case "4":
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
