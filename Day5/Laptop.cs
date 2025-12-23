using System;

namespace Day5;

public class Laptop : Computer
{
    #region Fields
    int _displaySize;
    int _batteryVolt;
    #endregion

    int Display_price = 250;
    int battery_supply = 20;

     public int DisplaySize
    {
        get { return _displaySize; }
        set { _displaySize = value; }
    }

    public int BatteryVolt
    {
        get { return _batteryVolt; }
        set { _batteryVolt = value; }
    }
    public double LaptopPriceCalculation()
    {
        double processor_Cost = 0;
        if (Processor == "i3")
        {
            processor_Cost = 2500;
        }
        else if (Processor == "i5")
        {
            processor_Cost = 5000;
        }
        else if (Processor == "i7")
        {
            processor_Cost = 6500;
        }

        double laptop_price = processor_Cost + (RamSize * Ramprice) + (hardDiskSize * Hard_Disk_Price) + (GraphicCard * GraphicCardPrice) + (_displaySize * Display_price) + (_batteryVolt * battery_supply);

        return laptop_price;
    }

}
