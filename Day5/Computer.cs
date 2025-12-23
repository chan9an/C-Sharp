using System;

namespace Day5;

public class Computer
{

    #region Fields
    string _processor;
    int _ramSize;

    int _hardDiskSize;
    int _graphicCard;

    #endregion
    int _ramprice = 200;
    int _hard_Disk_Price = 1500;
    int _graphicCardPrice = 2500;

    //void processor
    public string Processor
    {
        get
        {
            return _processor;
        }
        set
        {
            _processor = value;

        }

    }
    public int RamSize
    {
        get
        {
            return _ramSize;
        }
        set
        {
            _ramSize = value;

        }


    }
    public int hardDiskSize
    {
        get
        {
            return _hardDiskSize;
        }
        set
        {
            _hardDiskSize = value;

        }


    }
    public int GraphicCard
    {
        get
        {
            return _graphicCard;
        }
        set
        {
            _graphicCard = value;

        }


    }
    public int Hard_Disk_Price{
        get{
            return _hard_Disk_Price;

    }
    }
    public int Ramprice{
        get{
            return _ramprice;

    }
    }
    public int GraphicCardPrice {
        get{
            return _graphicCardPrice;

    }
    }
    

}
