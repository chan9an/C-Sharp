using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryFine
{
    public class Member
    {
        public string MemberId { get; set; }
        public string Name { get; set; }
        public int FineAmount { get; set; }

        public Member(string memberId, string name, int fineAmount)
        {
            MemberId = memberId;
            Name = name;
            FineAmount = fineAmount;
        }
    }

    public class InvalidFineException : Exception
    {
        public InvalidFineException(string message) : base(message) { }
    }

    public class MemberNotFoundException : Exception
    {
        public MemberNotFoundException(string message) : base(message) { }
    }

    public class DescendingComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    public class MemberUtility
    {
        private SortedDictionary<int, List<Member>> members = new SortedDictionary<int, List<Member>>(new DescendingComparer());

        public void AddMember(Member member)
        {
            if (member.FineAmount < 0)
                throw new InvalidFineException("Fine amount cannot be negative.");

            if (!members.ContainsKey(member.FineAmount))
                members[member.FineAmount] = new List<Member>();
            
            members[member.FineAmount].Add(member);
        }

        public void PayFine(string memberId, int payAmount)
        {
            Member target = null;
            int oldFine = -1;

            foreach (var pair in members)
            {
                var m = pair.Value.FirstOrDefault(x => x.MemberId == memberId);
                if (m != null)
                {
                    target = m;
                    oldFine = pair.Key;
                    break;
                }
            }

            if (target == null)
                throw new MemberNotFoundException($"Member with ID {memberId} not found.");

            if (payAmount <= 0)
                throw new Exception("Payment amount must be positive.");
            
            if (payAmount > target.FineAmount)
                throw new Exception("Payment exceeds fine amount.");

            int newFine = target.FineAmount - payAmount;

            // Remove and Re-add
            members[oldFine].Remove(target);
            if (members[oldFine].Count == 0)
                members.Remove(oldFine);

            target.FineAmount = newFine;
            if (!members.ContainsKey(newFine))
                members[newFine] = new List<Member>();
            members[newFine].Add(target);
        }

        public List<Member> GetAllMembers()
        {
            List<Member> all = new List<Member>();
            foreach (var pair in members)
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
            MemberUtility utility = new MemberUtility();

            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1 -> Display Members by Fine");
                Console.WriteLine("2 -> Pay Fine");
                Console.WriteLine("3 -> Add Member");
                Console.WriteLine("4 -> Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var list = utility.GetAllMembers();
                            if (list.Count == 0)
                                Console.WriteLine("No members found.");
                            else
                            {
                                foreach (var m in list)
                                    Console.WriteLine($"Details: {m.MemberId} {m.Name} {m.FineAmount}");
                            }
                            break;

                        case "2":
                            Console.Write("Member ID: ");
                            string id = Console.ReadLine();
                            Console.Write("Payment Amount: ");
                            if (int.TryParse(Console.ReadLine(), out int amt))
                            {
                                utility.PayFine(id, amt);
                                Console.WriteLine("Fine paid successfully.");
                            }
                            break;

                        case "3":
                            Console.WriteLine("Enter details (ID Name Fine):");
                            string[] p = Console.ReadLine().Split(' ');
                            if (p.Length == 3)
                            {
                                utility.AddMember(new Member(p[0], p[1], int.Parse(p[2])));
                                Console.WriteLine("Member added successfully.");
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
