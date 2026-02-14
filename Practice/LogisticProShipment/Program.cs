using System;

namespace LogisticProShipment;

public class Program
{


    static void Main(string[] args)
    {
        Shipment shipObj = new Shipment();
        ShipmentDetails shipDetailObj = new ShipmentDetails();


        Console.WriteLine("Input ID: ");
        shipObj.ShipmentCode = Console.ReadLine();
        Console.WriteLine("Mode: ");
        shipObj.TransportMode = Console.ReadLine();
        Console.WriteLine("Weight: ");
        shipObj.Weight = double.Parse(Console.ReadLine());
        Console.WriteLine("Storage: ");
        shipObj.StorageDays = int.Parse(Console.ReadLine());
        if (shipDetailObj.ValidateShipmentCode())
        {
            

        }
        else
        {
            Console.WriteLine("Invalid shipment Code");
        }
        

    }


}
