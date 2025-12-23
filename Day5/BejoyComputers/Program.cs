using System;

namespace Day5;

class Program
{
    static void Main()
    {
        Console.WriteLine("1.Desktop");
        Console.WriteLine("2.Laptop");
        Console.WriteLine("Choose the option");

        int choice = Int32.Parse(Console.ReadLine());

        if (choice == 1)
        {
            Desktop d = new Desktop();

            Console.WriteLine("Enter the processor");
            d.Processor = Console.ReadLine();

            Console.WriteLine("Enter the ram size");
            d.RamSize = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the hard disk size");
            d.hardDiskSize = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the graphic card size");
            d.GraphicCard = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the monitor size");
            d.MonitorSize = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the power supply volt");
            d.PowerSupplyVolt = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Desktop price is " + d.DesktopPriceCalculation());
        }
        else if (choice == 2)
        { 
            Laptop l = new Laptop();

            Console.WriteLine("Enter the processor");
            l.Processor = Console.ReadLine();

            Console.WriteLine("Enter the ram size");
            l.RamSize = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the hard disk size");
            l.hardDiskSize = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the graphic card size");
            l.GraphicCard = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the display size");
            l.DisplaySize = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Enter the battery volt");
            l.BatteryVolt = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Laptop price is " + l.LaptopPriceCalculation());
        }
    }
}
