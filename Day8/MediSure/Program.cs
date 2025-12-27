using System;
using MediSure;

public class Program
{
    static PatientBill LastBill;
    static bool HasLastBill = false;

    public static void Main(string[] args)
    {
        bool run = true;

        while (run)
        {
            Console.WriteLine("================== MediSure Clinic Billing ==================");
            Console.WriteLine("1. Create New Bill (Enter Patient Details)");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your option: ");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                PatientBill bill = new PatientBill();

                Console.Write("Enter Bill Id: ");
                bill.BillId = Console.ReadLine();

                Console.Write("Enter Patient Name: ");
                bill.PatientName = Console.ReadLine();

                Console.Write("Is the patient insured? (Y/N): ");
                string testBool = Console.ReadLine();
                    if (testBool == "Y" || testBool == "y")
                    {
                        bill.HasInsurance = true;
                    }
                    else
                    {
                        bill.HasInsurance = false;

                    }
                    
                Console.Write("Enter Consultation Fee: ");
                bill.ConsultationFee = decimal.Parse(Console.ReadLine());

                Console.Write("Enter Lab Charges: ");
                bill.LabCharges = decimal.Parse(Console.ReadLine());

                Console.Write("Enter Medicine Charges: ");
                bill.MedicineCharges = decimal.Parse(Console.ReadLine());

                bill.CalculateBill();

                LastBill = bill;
                HasLastBill = true;

                Console.WriteLine("Bill created successfully.");
                Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
                Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
                Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
                Console.WriteLine("------------------------------------------------------------");


                break;

                case 2:
                    if (!HasLastBill)
                    {
                        Console.WriteLine("No bill available. Please create a new bill first.");
                        return;
                    }

                    Console.WriteLine("----------- Last Bill -----------");
                    Console.WriteLine($"BillId: {LastBill.BillId}");
                    Console.WriteLine($"Patient: {LastBill.PatientName}");
                    Console.WriteLine($"Insured: {(LastBill.HasInsurance ? "Yes" : "No")}");
                    Console.WriteLine($"Consultation Fee: {LastBill.ConsultationFee:F2}");
                    Console.WriteLine($"Lab Charges: {LastBill.LabCharges:F2}");
                    Console.WriteLine($"Medicine Charges: {LastBill.MedicineCharges:F2}");
                    Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
                    Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
                    Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
                    Console.WriteLine("--------------------------------");
                    Console.WriteLine("------------------------------------------------------------");
                    break;

                case 3:
                    LastBill = null;
                    HasLastBill = false;
                    Console.WriteLine("Last bill cleared.");
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
