using System;
using System.Collections.Generic;
using System.Linq;

namespace BankBalance
{
    public class Account
    {
        public string AccountNumber { get; set; }
        public string HolderName { get; set; }
        public decimal Balance { get; set; }

        public Account(string accountNumber, string holderName, decimal balance)
        {
            AccountNumber = accountNumber;
            HolderName = holderName;
            Balance = balance;
        }
    }

    public class NegativeBalanceException : Exception
    {
        public NegativeBalanceException(string message) : base(message) { }
    }

    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string message) : base(message) { }
    }

    public class AccountNotFoundException : Exception
    {
        public AccountNotFoundException(string message) : base(message) { }
    }

    public class BankManager
    {
        private SortedDictionary<decimal, List<Account>> accounts = new SortedDictionary<decimal, List<Account>>();

        public void AddAccount(Account account)
        {
            if (account.Balance < 0)
                throw new NegativeBalanceException("Initial balance cannot be negative.");

            if (!accounts.ContainsKey(account.Balance))
                accounts[account.Balance] = new List<Account>();
            
            accounts[account.Balance].Add(account);
        }

        public void Deposit(string accNo, decimal amount)
        {
            if (amount <= 0)
                throw new Exception("Deposit amount must be positive.");

            UpdateBalance(accNo, amount);
        }

        public void Withdraw(string accNo, decimal amount)
        {
            if (amount <= 0)
                throw new Exception("Withdrawal amount must be positive.");

            UpdateBalance(accNo, -amount);
        }

        private void UpdateBalance(string accNo, decimal delta)
        {
            Account target = null;
            decimal oldBalance = -1;

            foreach (var pair in accounts)
            {
                var acc = pair.Value.FirstOrDefault(a => a.AccountNumber == accNo);
                if (acc != null)
                {
                    target = acc;
                    oldBalance = pair.Key;
                    break;
                }
            }

            if (target == null)
                throw new AccountNotFoundException($"Account {accNo} not found.");

            decimal newBalance = oldBalance + delta;
            if (newBalance < 0)
                throw new InsufficientFundsException("Insufficient funds for this transaction.");

            // Remove from old balance list
            accounts[oldBalance].Remove(target);
            if (accounts[oldBalance].Count == 0)
                accounts.Remove(oldBalance);

            // Update balance and re-insert
            target.Balance = newBalance;
            if (!accounts.ContainsKey(newBalance))
                accounts[newBalance] = new List<Account>();
            accounts[newBalance].Add(target);
        }

        public List<Account> GetAllAccounts()
        {
            List<Account> all = new List<Account>();
            foreach (var pair in accounts)
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
            BankManager manager = new BankManager();

            while (true)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1 -> Display Accounts");
                Console.WriteLine("2 -> Deposit");
                Console.WriteLine("3 -> Withdraw");
                Console.WriteLine("4 -> Exit");
                Console.Write("Enter choice: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            var all = manager.GetAllAccounts();
                            if (all.Count == 0)
                            {
                                Console.WriteLine("No accounts found.");
                            }
                            else
                            {
                                foreach (var a in all)
                                {
                                    Console.WriteLine($"Details: {a.AccountNumber} {a.HolderName} {a.Balance}");
                                }
                            }
                            break;

                        case "2":
                            Console.Write("Account Number: ");
                            string depAcc = Console.ReadLine();
                            Console.Write("Amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal depAmt))
                            {
                                manager.Deposit(depAcc, depAmt);
                                Console.WriteLine("Deposit successful.");
                            }
                            break;

                        case "3":
                            Console.Write("Account Number: ");
                            string witAcc = Console.ReadLine();
                            Console.Write("Amount: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal witAmt))
                            {
                                manager.Withdraw(witAcc, witAmt);
                                Console.WriteLine("Withdrawal successful.");
                            }
                            break;

                        case "4":
                            Environment.Exit(0);
                            break;
                        
                        case "add": // Secret add for testing
                            Console.WriteLine("Enter details (AccNo Name Balance):");
                            string[] p = Console.ReadLine().Split(' ');
                            manager.AddAccount(new Account(p[0], p[1], decimal.Parse(p[2])));
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
