using System;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceOrder
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public int OrderAmount { get; set; }

        public Order(string id, string name, int amount)
        {
            OrderId = id;
            CustomerName = name;
            OrderAmount = amount;
        }
    }

    public class InvalidOrderAmountException : Exception
    {
        public InvalidOrderAmountException(string message) : base(message) { }
    }

    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException(string message) : base(message) { }
    }

    public class DescendingComparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y.CompareTo(x);
        }
    }

    public class OrderManager
    {
        private SortedDictionary<int, List<Order>> orders = new SortedDictionary<int, List<Order>>(new DescendingComparer());

        public void AddOrder(Order o)
        {
            if (o.OrderAmount <= 0)
                throw new InvalidOrderAmountException("Order amount must be greater than zero.");

            if (!orders.ContainsKey(o.OrderAmount))
                orders[o.OrderAmount] = new List<Order>();
            
            orders[o.OrderAmount].Add(o);
        }

        public void UpdateOrder(string orderId, int newAmount)
        {
            if (newAmount <= 0)
                throw new InvalidOrderAmountException("Order amount must be greater than zero.");

            Order target = null;
            int oldAmount = -1;

            foreach (var pair in orders)
            {
                var o = pair.Value.FirstOrDefault(x => x.OrderId == orderId);
                if (o != null)
                {
                    target = o;
                    oldAmount = pair.Key;
                    break;
                }
            }

            if (target == null)
                throw new OrderNotFoundException($"Order {orderId} not found.");

            // Remove and Re-add
            orders[oldAmount].Remove(target);
            if (orders[oldAmount].Count == 0)
                orders.Remove(oldAmount);

            target.OrderAmount = newAmount;
            if (!orders.ContainsKey(newAmount))
                orders[newAmount] = new List<Order>();
            orders[newAmount].Add(target);
        }

        public List<Order> GetAllOrders()
        {
            List<Order> all = new List<Order>();
            foreach (var pair in orders)
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
            OrderManager manager = new OrderManager();

            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1 -> Display Orders");
                Console.WriteLine("2 -> Update Order");
                Console.WriteLine("3 -> Add Order");
                Console.WriteLine("4 -> Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var list = manager.GetAllOrders();
                            if (list.Count == 0)
                                Console.WriteLine("No orders found.");
                            else
                            {
                                foreach (var o in list)
                                    Console.WriteLine($"Details: {o.OrderId} {o.CustomerName} {o.OrderAmount}");
                            }
                            break;

                        case "2":
                            Console.Write("Order ID: ");
                            string id = Console.ReadLine();
                            Console.Write("New Amount: ");
                            if (int.TryParse(Console.ReadLine(), out int amt))
                            {
                                manager.UpdateOrder(id, amt);
                                Console.WriteLine("Order updated successfully.");
                            }
                            break;

                        case "3":
                            Console.WriteLine("Enter details (ID CustomerName Amount):");
                            string[] p = Console.ReadLine().Split(' ');
                            if (p.Length == 3)
                            {
                                manager.AddOrder(new Order(p[0], p[1], int.Parse(p[2])));
                                Console.WriteLine("Order added successfully.");
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
