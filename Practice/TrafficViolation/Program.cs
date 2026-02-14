using System;
using System.Collections.Generic;
using System.Linq;

namespace TrafficViolation
{
    public class Violation
    {
        public string VehicleNumber { get; set; }
        public string OwnerName { get; set; }
        public int FineAmount { get; set; }

        public Violation(string vehNo, string owner, int fine)
        {
            VehicleNumber = vehNo;
            OwnerName = owner;
            FineAmount = fine;
        }
    }

    public class InvalidFineAmountException : Exception
    {
        public InvalidFineAmountException(string message) : base(message) { }
    }

    public class DuplicateViolationException : Exception
    {
        public DuplicateViolationException(string message) : base(message) { }
    }

    public class DescendingComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    public class ViolationManager
    {
        private SortedDictionary<int, List<Violation>> violations = new SortedDictionary<int, List<Violation>>(new DescendingComparer());

        public void AddViolation(Violation v)
        {
            if (v.FineAmount < 0)
                throw new InvalidFineAmountException("Fine amount cannot be negative.");

            foreach (var list in violations.Values)
            {
                if (list.Any(x => x.VehicleNumber == v.VehicleNumber))
                    throw new DuplicateViolationException($"Violation for vehicle {v.VehicleNumber} already exists.");
            }

            if (!violations.ContainsKey(v.FineAmount))
                violations[v.FineAmount] = new List<Violation>();
            
            violations[v.FineAmount].Add(v);
        }

        public void PayFine(string vehNo)
        {
            Violation target = null;
            int oldFine = -1;

            foreach (var pair in violations)
            {
                var v = pair.Value.FirstOrDefault(x => x.VehicleNumber == vehNo);
                if (v != null)
                {
                    target = v;
                    oldFine = pair.Key;
                    break;
                }
            }

            if (target == null)
                throw new Exception("Violation not found.");

            // Basic Pay Fine implementation (remove violation if paid)
            violations[oldFine].Remove(target);
            if (violations[oldFine].Count == 0)
                violations.Remove(oldFine);
        }

        public List<Violation> GetAllViolations()
        {
            List<Violation> all = new List<Violation>();
            foreach (var pair in violations)
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
            ViolationManager manager = new ViolationManager();

            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1 -> Display Violations");
                Console.WriteLine("2 -> Pay Fine");
                Console.WriteLine("3 -> Add Violation");
                Console.WriteLine("4 -> Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var list = manager.GetAllViolations();
                            if (list.Count == 0)
                                Console.WriteLine("No violations found.");
                            else
                            {
                                foreach (var v in list)
                                    Console.WriteLine($"Details: {v.VehicleNumber} {v.OwnerName} {v.FineAmount}");
                            }
                            break;

                        case "2":
                            Console.Write("Vehicle Number: ");
                            string vehNo = Console.ReadLine();
                            manager.PayFine(vehNo);
                            Console.WriteLine("Fine paid/Violation removed successfully.");
                            break;

                        case "3":
                            Console.WriteLine("Enter details (VehicleNo Owner Fine):");
                            string[] p = Console.ReadLine().Split(' ');
                            if (p.Length == 3)
                            {
                                manager.AddViolation(new Violation(p[0], p[1], int.Parse(p[2])));
                                Console.WriteLine("Violation added successfully.");
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
