using System;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace Day5;

public class Desktop : Computer
{
    #region Fields
    int _monitorSize;
    int _powerSupplyVolt;
    #endregion

    int monitor_price = 250;
    int power_supply = 20;
    
    


 public int MonitorSize
    {
        get { return _monitorSize; }
        set { _monitorSize = value; }
    }

    public int PowerSupplyVolt
    {
        get { return _powerSupplyVolt; }
        set { _powerSupplyVolt = value; }
    }

    public double DesktopPriceCalculation()
    {
        double processor_Cost = 0;
        if (Processor == "i3")
        {
            processor_Cost = 1500;
        }
        else if (Processor == "i5")
        {
            processor_Cost = 3000;
        }
        else if (Processor == "i7")
        {
            processor_Cost = 4500;
        }

        double desktop_price = processor_Cost + (RamSize * Ramprice) + (hardDiskSize * Hard_Disk_Price) + (GraphicCard * GraphicCardPrice) + (_monitorSize * monitor_price) + (_powerSupplyVolt * power_supply);

        return desktop_price;
    }

   

}
