using ServiceLibrary;
class Program
{
    static void Main(string[] args)
    {
        int num1;
        int num2;
        System.Console.WriteLine("Enter First Number: ");
        num1 = Int32.Parse(Console.ReadLine());
        System.Console.WriteLine("\nEnter Second Number: ");
        num2 = Int32.Parse(Console.ReadLine());

        SomeLogic logic = new SomeLogic();

    }
}

internal class SomeLogic
{
    public SomeLogic()
    {
    }
}