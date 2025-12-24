using library_management_system;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter the title");
        string title = Console.ReadLine();

        Console.WriteLine("Enter the author");
        string author = Console.ReadLine();

        Console.WriteLine("Enter the number of pages");
        int pages = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Enter the due date");
        DateTime due = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter the return date");
        DateTime returned = DateTime.Parse(Console.ReadLine());

        Console.WriteLine("Enter the days to read");
        int days = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Enter the daily late feeRate");
        double rate = double.Parse(Console.ReadLine());

        
        Book bObj = new Book(title, author, pages, due, returned);

        Console.WriteLine($"Average Pages Read Per Day : {bObj.AveragePagesReadPerDay(days)}");
        Console.WriteLine($"Late Fee : {bObj.CalculateLateFee(rate)}");
    }
}