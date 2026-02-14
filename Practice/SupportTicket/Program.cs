using System;
using System.Collections.Generic;
using System.Linq;

namespace SupportTicketNamespace
{
    public class SupportTicket
    {
        public string TicketId { get; set; }
        public string IssueDescription { get; set; }
        public int SeverityLevel { get; set; }

        public SupportTicket(string id, string desc, int severity)
        {
            TicketId = id;
            IssueDescription = desc;
            SeverityLevel = severity;
        }
    }

    public class InvalidSeverityException : Exception
    {
        public InvalidSeverityException(string message) : base(message) { }
    }

    public class TicketNotFoundException : Exception
    {
        public TicketNotFoundException(string message) : base(message) { }
    }

    public class TicketManager
    {
        private SortedDictionary<int, Queue<SupportTicket>> tickets = new SortedDictionary<int, Queue<SupportTicket>>();

        public void AddTicket(SupportTicket ticket)
        {
            if (ticket.SeverityLevel <= 0)
                throw new InvalidSeverityException("Severity level must be a positive integer.");

            if (!tickets.ContainsKey(ticket.SeverityLevel))
                tickets[ticket.SeverityLevel] = new Queue<SupportTicket>();
            
            tickets[ticket.SeverityLevel].Enqueue(ticket);
        }

        public void EscalateTicket(string ticketId, int newSeverity)
        {
            if (newSeverity <= 0)
                throw new InvalidSeverityException("Severity level must be a positive integer.");

            SupportTicket target = null;
            int oldSeverity = -1;

            foreach (var pair in tickets)
            {
                var list = pair.Value.ToList();
                var t = list.FirstOrDefault(x => x.TicketId == ticketId);
                if (t != null)
                {
                    target = t;
                    oldSeverity = pair.Key;
                    break;
                }
            }

            if (target == null)
                throw new TicketNotFoundException($"Ticket {ticketId} not found.");

            // Remove from old queue (need to rebuild queue)
            var oldQueue = tickets[oldSeverity];
            var newQueue = new Queue<SupportTicket>();
            while (oldQueue.Count > 0)
            {
                var item = oldQueue.Dequeue();
                if (item.TicketId != ticketId)
                    newQueue.Enqueue(item);
            }
            if (newQueue.Count == 0)
                tickets.Remove(oldSeverity);
            else
                tickets[oldSeverity] = newQueue;

            // Add to new severity
            target.SeverityLevel = newSeverity;
            if (!tickets.ContainsKey(newSeverity))
                tickets[newSeverity] = new Queue<SupportTicket>();
            tickets[newSeverity].Enqueue(target);
        }

        public List<SupportTicket> GetAllTickets()
        {
            List<SupportTicket> all = new List<SupportTicket>();
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
            TicketManager manager = new TicketManager();

            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1 -> Display Tickets by Priority");
                Console.WriteLine("2 -> Escalate Ticket");
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
                                    Console.WriteLine($"Details: {t.TicketId} {t.IssueDescription} {t.SeverityLevel}");
                            }
                            break;

                        case "2":
                            Console.Write("Ticket ID: ");
                            string id = Console.ReadLine();
                            Console.Write("New Severity Level: ");
                            if (int.TryParse(Console.ReadLine(), out int sev))
                            {
                                manager.EscalateTicket(id, sev);
                                Console.WriteLine("Ticket escalated successfully.");
                            }
                            break;

                        case "3":
                            Console.WriteLine("Enter details (ID Description Severity):");
                            string input = Console.ReadLine();
                            string[] p = input.Split(' ');
                            if (p.Length >= 3)
                            {
                                string ticketId = p[0];
                                int severity = int.Parse(p[p.Length - 1]);
                                string desc = string.Join(" ", p.Skip(1).Take(p.Length - 2));
                                manager.AddTicket(new SupportTicket(ticketId, desc, severity));
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
