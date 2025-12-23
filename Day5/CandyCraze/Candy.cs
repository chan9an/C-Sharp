using System;

namespace Day5.CandyCraze;

public class Candy
{
    #region Fields
    string _flavour;
    int _quantity;
    int _pricePerPiece;
    double _totalPrice;
    double _discount;

    #endregion
    public string Flavour
    {
        get
        {
            return _flavour;
        }
        set
        {
            _flavour = value;
        }
    }
    public int Quantity
    {
        get
        {
            return _quantity;
        }
        set
        {
            _quantity = value;
        }
    }
    public int PricePerPiece
    {
        get
        {
            return _pricePerPiece;
        }
        set
        {
            _pricePerPiece = value;
        }
    }
    public double TotalPrice
    {
        get
        {
            return _totalPrice;
        }
        set
        {
            _totalPrice = value;
        }
    }
    public double Discount
    {
        get
        {
            return _discount;
        }
        set
        {
            _discount = value;
        }
    }
    public bool ValidateCandyFlavour(string flavour)
    {
        if (flavour == "Strawberry" || flavour == "Mint" || flavour == "Lemon") return true;
        else return false;
        
    }

}
