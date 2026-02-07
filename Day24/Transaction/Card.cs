using System;
using Microsoft.VisualBasic;

namespace Transaction;

public class Card
{
    #region  fields
    private string _name;
    private string _number;
    private int _cvv;
    private DateTime _expiry;
    public string _bank;
    #endregion


    #region constructor
    public Card(
    string name,
    string number,
    int cvv,
    DateTime expiry,
    string bank)

    {
        _name = name;
        _number = number;
        _cvv = cvv;
        _expiry = expiry;
        _bank = bank;
    }

    #endregion


    #region properties
    public string Bank => _bank;
    public DateTime Expiry => _expiry;

    internal string FullCardNumber => _number;
    #endregion

}
