using System;

namespace Transaction;


public class Transactions
{
    #region  fields
    private string _transactionID;
    private DateTime _time;
    private Card _card;
    private double _amount;
    private string _city;
    private string _receiverAccount;

    #endregion


    #region constructor

    public Transactions(
            string transactionID,
            DateTime time,
            Card card,
            double amount,
            string city,
            string receiverAccount)
    {
        _transactionID = transactionID;
        _time = time;
        _card = card;
        _amount = amount;
        _city = city;
        _receiverAccount = receiverAccount;
    }


    #endregion

    #region properties

    public string TransactionID => _transactionID;
    public DateTime Time => _time;
    public Card Card => _card;
    public double Amount => _amount;
    public string City => _city;
    public string ReceiverAccount => _receiverAccount;
        
    #endregion



}
