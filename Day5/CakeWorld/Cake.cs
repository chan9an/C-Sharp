using System;

namespace Day5.CakeWorld;

public class Cake
{
    #region Fields
    string _flavour;
    int _quantityInKg;
    double _pricePerKg;
    #endregion

    public string Flavour
    {
        get
        {
            return _flavour;
        }
        set
        {
            value = _flavour;

        }
    }
    public int QuantityInKg
    {
        get
        {
            return _quantityInKg;
        }
        set
        {
            value = _quantityInKg;

        }
    }
    public double PricePerKg
    {
        get
        {
            return _pricePerKg;
        }
        set
        {
            value = _pricePerKg;

        }
    }
    public bool CakeOrder()
    {
        if (Flavour == "Chocolate" || Flavour == "Red Velvet" || Flavour == "Vanilla")
        {
            return true;
        }
        else
        {
            return false;
        }
    }


}
