using System;
using System.Collections.Generic;
using System.Linq;

namespace PharmacyInventory
{
    public class Medicine
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int ExpiryYear { get; set; }

        public Medicine(string id, string name, int price, int expiryYear)
        {
            Id = id;
            Name = name;
            Price = price;
            ExpiryYear = expiryYear;
        }
    }

    public class InvalidPriceException : Exception
    {
        public InvalidPriceException(string message) : base(message) { }
    }

    public class DuplicateMedicineException : Exception
    {
        public DuplicateMedicineException(string message) : base(message) { }
    }

    public class InvalidExpiryYearException : Exception
    {
        public InvalidExpiryYearException(string message) : base(message) { }
    }

    public class MedicineNotFoundException : Exception
    {
        public MedicineNotFoundException(string message) : base(message) { }
    }

    public class MedicineUtility
    {
        private SortedDictionary<int, List<Medicine>> medicines = new SortedDictionary<int, List<Medicine>>();

        public void AddMedicine(Medicine medicine)
        {
            if (medicine.Price <= 0)
                throw new InvalidPriceException("Price must be greater than zero.");
            
            if (medicine.ExpiryYear < DateTime.Now.Year)
                throw new InvalidExpiryYearException("Expiry year cannot be in the past.");

            foreach (var list in medicines.Values)
            {
                if (list.Any(m => m.Id == medicine.Id))
                    throw new DuplicateMedicineException($"Medicine with ID {medicine.Id} already exists.");
            }

            if (!medicines.ContainsKey(medicine.ExpiryYear))
            {
                medicines[medicine.ExpiryYear] = new List<Medicine>();
            }
            medicines[medicine.ExpiryYear].Add(medicine);
        }

        public List<Medicine> GetAllMedicines()
        {
            List<Medicine> all = new List<Medicine>();
            foreach (var pair in medicines)
            {
                all.AddRange(pair.Value);
            }
            return all;
        }

        public void UpdateMedicinePrice(string id, int newPrice)
        {
            if (newPrice <= 0)
                throw new InvalidPriceException("Price must be greater than zero.");

            bool found = false;
            foreach (var list in medicines.Values)
            {
                var med = list.FirstOrDefault(m => m.Id == id);
                if (med != null)
                {
                    med.Price = newPrice;
                    found = true;
                    break;
                }
            }

            if (!found)
                throw new MedicineNotFoundException($"Medicine with ID {id} not found.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MedicineUtility utility = new MedicineUtility();

            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1 -> Display all medicines");
                Console.WriteLine("2 -> Update medicine price");
                Console.WriteLine("3 -> Add medicine");
                Console.WriteLine("4 -> Exit");
                Console.Write("Enter choice: ");
                
                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var all = utility.GetAllMedicines();
                            if (all.Count == 0)
                            {
                                Console.WriteLine("No medicines found.");
                            }
                            else
                            {
                                foreach (var m in all)
                                {
                                    Console.WriteLine($"Details: {m.Id} {m.Name} {m.Price} {m.ExpiryYear}");
                                }
                            }
                            break;

                        case "2":
                            Console.Write("Enter Medicine ID: ");
                            string updateId = Console.ReadLine();
                            Console.Write("Enter New Price: ");
                            if (int.TryParse(Console.ReadLine(), out int newPrice))
                            {
                                utility.UpdateMedicinePrice(updateId, newPrice);
                                Console.WriteLine("Price updated successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid price input.");
                            }
                            break;

                        case "3":
                            Console.WriteLine("Enter details (ID Name Price ExpiryYear):");
                            string input = Console.ReadLine();
                            string[] parts = input.Split(' ');
                            if (parts.Length == 4)
                            {
                                string id = parts[0];
                                string name = parts[1];
                                int price = int.Parse(parts[2]);
                                int expiry = int.Parse(parts[3]);
                                utility.AddMedicine(new Medicine(id, name, price, expiry));
                                Console.WriteLine("Medicine added successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input format.");
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
