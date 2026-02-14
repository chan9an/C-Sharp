using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestmentRisk
{
    public class Investment
    {
        public string InvestmentId { get; set; }
        public string AssetName { get; set; }
        public int RiskRating { get; set; }

        public Investment(string id, string name, int rating)
        {
            InvestmentId = id;
            AssetName = name;
            RiskRating = rating;
        }
    }

    public class InvalidRiskRatingException : Exception
    {
        public InvalidRiskRatingException(string message) : base(message) { }
    }

    public class DuplicateInvestmentException : Exception
    {
        public DuplicateInvestmentException(string message) : base(message) { }
    }

    public class InvestmentManager
    {
        private SortedDictionary<int, List<Investment>> investments = new SortedDictionary<int, List<Investment>>();

        public void AddInvestment(Investment inv)
        {
            if (inv.RiskRating < 1 || inv.RiskRating > 5)
                throw new InvalidRiskRatingException("Risk rating must be between 1 and 5.");

            foreach (var list in investments.Values)
            {
                if (list.Any(x => x.InvestmentId == inv.InvestmentId))
                    throw new DuplicateInvestmentException($"Investment ID {inv.InvestmentId} already exists.");
            }

            if (!investments.ContainsKey(inv.RiskRating))
                investments[inv.RiskRating] = new List<Investment>();
            
            investments[inv.RiskRating].Add(inv);
        }

        public void UpdateRisk(string id, int newRating)
        {
            if (newRating < 1 || newRating > 5)
                throw new InvalidRiskRatingException("Risk rating must be between 1 and 5.");

            Investment target = null;
            int oldRating = -1;

            foreach (var pair in investments)
            {
                var inv = pair.Value.FirstOrDefault(x => x.InvestmentId == id);
                if (inv != null)
                {
                    target = inv;
                    oldRating = pair.Key;
                    break;
                }
            }

            if (target == null)
                throw new Exception("Investment not found.");

            // Remove and Re-add
            investments[oldRating].Remove(target);
            if (investments[oldRating].Count == 0)
                investments.Remove(oldRating);

            target.RiskRating = newRating;
            if (!investments.ContainsKey(newRating))
                investments[newRating] = new List<Investment>();
            investments[newRating].Add(target);
        }

        public List<Investment> GetAllInvestments()
        {
            List<Investment> all = new List<Investment>();
            foreach (var pair in investments)
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
            InvestmentManager manager = new InvestmentManager();

            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1 -> Display Investments");
                Console.WriteLine("2 -> Update Risk");
                Console.WriteLine("3 -> Add Investment");
                Console.WriteLine("4 -> Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var list = manager.GetAllInvestments();
                            if (list.Count == 0)
                                Console.WriteLine("No investments found.");
                            else
                            {
                                foreach (var i in list)
                                    Console.WriteLine($"Details: {i.InvestmentId} {i.AssetName} {i.RiskRating}");
                            }
                            break;

                        case "2":
                            Console.Write("Investment ID: ");
                            string id = Console.ReadLine();
                            Console.Write("New Risk Rating (1-5): ");
                            if (int.TryParse(Console.ReadLine(), out int rating))
                            {
                                manager.UpdateRisk(id, rating);
                                Console.WriteLine("Risk rating updated successfully.");
                            }
                            break;

                        case "3":
                            Console.WriteLine("Enter details (ID AssetName RiskRating):");
                            string[] p = Console.ReadLine().Split(' ');
                            if (p.Length == 3)
                            {
                                manager.AddInvestment(new Investment(p[0], p[1], int.Parse(p[2])));
                                Console.WriteLine("Investment added successfully.");
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
