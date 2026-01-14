using System;

namespace Khata;

public class Khata
{
    private Dictionary<string, int> record;

    public Khata(Dictionary<string, int> record)
    {
        this.record = new Dictionary<string, int>(record);
    }

    public int getTotal()
    {
        int total = 0;

        foreach (KeyValuePair<string, int> entry in record)
        {
            total += entry.Value;
        }

        return total;
    }

    public int getRepeatAmount()
    {
        Dictionary<int, int> amountCount = new Dictionary<int, int>();

        foreach (KeyValuePair<string, int> entry in record)
        {
            int amount = entry.Value;

            if (amountCount.ContainsKey(amount))
            {
                amountCount[amount]++;
            }
            else
            {
                amountCount[amount] = 1;
            }
        }

        int repeatCount = 0;
        foreach (KeyValuePair<int, int> entry in amountCount)
        {
            if (entry.Value > 1)
            {
                repeatCount++;
            }
        }

        return repeatCount;
    }

    public void AddItem(string itemName, int amount)
    {
        if (record.ContainsKey(itemName))
        {
            throw new ArgumentException("Item name already exists.");
        }

        record[itemName] = amount;
    }
}



