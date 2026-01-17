using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static SortedDictionary<string, long> ItemDetails =
        new SortedDictionary<string, long>();

    // Method 1
    public static SortedDictionary<string, long> FindItemDetails(long soldCount)
    {
        SortedDictionary<string, long> result =
            new SortedDictionary<string, long>();

        foreach (var item in ItemDetails)
        {
            if (item.Value == soldCount)
            {
                result.Add(item.Key, item.Value);
            }
        }

        return result;
    }

    public static List<string> FindMinAndMaxSoldItems()
    {
        List<string> result = new List<string>();

        long minSold = ItemDetails.Values.Min();
        long maxSold = ItemDetails.Values.Max();

        string minItem = ItemDetails.First(x => x.Value == minSold).Key;
        string maxItem = ItemDetails.First(x => x.Value == maxSold).Key;

        result.Add(minItem);
        result.Add(maxItem);

        return result;
    }

    public static Dictionary<string, long> SortByCount()
    {
        return ItemDetails
            .OrderBy(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);
    }

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string itemName = Console.ReadLine();
            long soldCount = long.Parse(Console.ReadLine());
            ItemDetails.Add(itemName, soldCount);
        }

        long searchCount = long.Parse(Console.ReadLine());

        var foundItems = FindItemDetails(searchCount);

        if (foundItems.Count == 0)
        {
            Console.WriteLine("Invalid sold count");
        }
        else
        {
            foreach (var item in foundItems)
            {
                Console.WriteLine(item.Key + " " + item.Value);
            }
        }

        var minMax = FindMinAndMaxSoldItems();
        Console.WriteLine(minMax[0]);
        Console.WriteLine(minMax[1]);

        var sortedItems = SortByCount();
        foreach (var item in sortedItems)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }
    }
}
