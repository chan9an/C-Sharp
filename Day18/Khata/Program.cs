namespace  Khata;
class Program
{
    static void Main()
    {
        Dictionary<string, int> record = new Dictionary<string, int>
        {
            { "Milk", 100 },
            { "Tea", 50 },
            { "Coffee", 100 },
            { "Sugar", 50 },
            { "Salt", 200 }
        };

        Khata khata = new Khata(record);

        Console.WriteLine("Total Amount: " + khata.getTotal());
        Console.WriteLine("Repeated Amount Count: " + khata.getRepeatAmount());

        khata.AddItem("Rice", 300);
        Console.WriteLine("Total Amount after adding Rice: " + khata.getTotal());
    }
}