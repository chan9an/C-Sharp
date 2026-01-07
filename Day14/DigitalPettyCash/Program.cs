using System;
using System.Collections.Generic;

namespace DigitalPettyCash;

class Program
{
    static void Main()
    {
        Ledger<IncomeTransaction> incomeLedger = new Ledger<IncomeTransaction>();
        Ledger<ExpenseTransaction> expenseLedger = new Ledger<ExpenseTransaction>();

        while (true)
        {
            Console.WriteLine("\n--- Digital Petty Cash ---");
            Console.WriteLine("1. Add Income");
            Console.WriteLine("2. Add Expense");
            Console.WriteLine("3. Show Totals & Balance");
            Console.WriteLine("4. Show All Transactions");
            Console.WriteLine("5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    IncomeTransaction income = new IncomeTransaction();
                    Console.Write("Date (yyyy-mm-dd): ");
                    income.Date = DateTime.Parse(Console.ReadLine());
                    Console.Write("Amount: ");
                    income.Amount = decimal.Parse(Console.ReadLine());
                    Console.Write("Description: ");
                    income.Description = Console.ReadLine();
                    Console.Write("Source: ");
                    income.Source = Console.ReadLine();
                    incomeLedger.AddEntry(income);
                    Console.WriteLine("Income added.");
                    break;

                case "2":
                    ExpenseTransaction expense = new ExpenseTransaction();
                    Console.Write("Date (yyyy-mm-dd): ");
                    expense.Date = DateTime.Parse(Console.ReadLine());
                    Console.Write("Amount: ");
                    expense.Amount = decimal.Parse(Console.ReadLine());
                    Console.Write("Description: ");
                    expense.Description = Console.ReadLine();
                    Console.Write("Category: ");
                    expense.Category = Console.ReadLine();
                    expenseLedger.AddEntry(expense);
                    Console.WriteLine("Expense added.");
                    break;

                case "3":
                    decimal totalIncome = incomeLedger.CalculateTotal();
                    decimal totalExpense = expenseLedger.CalculateTotal();
                    decimal balance = totalIncome - totalExpense;
                    Console.WriteLine("\nTotal Income: " + totalIncome);
                    Console.WriteLine("Total Expense: " + totalExpense);
                    Console.WriteLine("Net Balance: " + balance);
                    break;

                case "4":
                    List<Transaction> all = new List<Transaction>();
                    all.AddRange(incomeLedger.GetAll());
                    all.AddRange(expenseLedger.GetAll());
                    Console.WriteLine("\nAll Transactions:");
                    foreach (Transaction t in all)
                    {
                        Console.WriteLine(t.GetSummary());
                    }
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
