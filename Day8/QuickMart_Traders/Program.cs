using System;
using QuickMart_Traders;

public class Program
{
    static SaleTransaction LastTransaction;
    static bool HasLastTransaction = false;

    public static void Main(string[] args)
    {
        bool run = true;

        while (run)
        {
            Console.WriteLine("================== QuickMart Traders ==================");
            Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("2. View Last Transaction");
            Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    SaleTransaction t = new SaleTransaction();

                    Console.Write("Enter Invoice No: ");
                    t.InvoiceNo = Console.ReadLine();

                    Console.Write("Enter Customer Name: ");
                    t.CustomerName = Console.ReadLine();

                    Console.Write("Enter Item Name: ");
                    t.ItemName = Console.ReadLine();

                    Console.Write("Enter Quantity: ");
                    t.Quantity = int.Parse(Console.ReadLine());

                    Console.Write("Enter Purchase Amount (total): ");
                    t.PurchaseAmount = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter Selling Amount (total): ");
                    t.SellingAmount = decimal.Parse(Console.ReadLine());

                    t.CalculateProfitOrLoss();

                    LastTransaction = t;
                    HasLastTransaction = true;

                    Console.WriteLine("Transaction saved successfully.");
                    Console.WriteLine($"Status: {t.ProfitOrLossStatus}");
                    Console.WriteLine($"Profit/Loss Amount: {t.ProfitOrLossAmount:F2}");
                    Console.WriteLine($"Profit Margin (%): {t.ProfitMarginPercent:F2}");
                    Console.WriteLine("------------------------------------------------------");
                    break;

                case 2:
                    if (!HasLastTransaction)
                    {
                        Console.WriteLine("No transaction available. Please create a new transaction first.");
                        break;
                    }

                    Console.WriteLine("-------------- Last Transaction --------------");
                    Console.WriteLine($"InvoiceNo: {LastTransaction.InvoiceNo}");
                    Console.WriteLine($"Customer: {LastTransaction.CustomerName}");
                    Console.WriteLine($"Item: {LastTransaction.ItemName}");
                    Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
                    Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount:F2}");
                    Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount:F2}");
                    Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
                    Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
                    Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent:F2}");
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("------------------------------------------------------");
                    break;

                case 3:
                    if (!HasLastTransaction)
                    {
                        Console.WriteLine("No transaction available. Please create a new transaction first.");
                        break;
                    }

                    LastTransaction.CalculateProfitOrLoss();

                    Console.WriteLine("Recalculated Result:");
                    Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
                    Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
                    Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent:F2}");
                    Console.WriteLine("------------------------------------------------------");
                    break;

                case 4:
                    run = false;
                    Console.WriteLine("Thank you. Application closed normally.");
                    break;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }
    }
}
