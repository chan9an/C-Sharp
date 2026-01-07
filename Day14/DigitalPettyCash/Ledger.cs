using System;

namespace DigitalPettyCash;

public class Ledger<T> where T : Transaction
{
    private List<T> transactions = new List<T>();
    public void AddEntry(T trans)
    {
        transactions.Add(trans);
    }

    public List<T> GetTransactionsByDate(DateTime date)
    {
        List<T> result = new List<T>();

        foreach (T t in transactions)
        {
            if (t.Date.Date == date.Date)
            {
                result.Add(t);
            }
        }

        return result;
    }


    public decimal CalculateTotal()
    {
        decimal total = 0;

        foreach (T trans in transactions)
        {
            total = total + trans.Amount;
        }

        return total;
    }

    public List<T> GetAll()
    {
        return transactions;
    }
}
