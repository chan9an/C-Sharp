using System;
using System.Linq;

namespace EComm;

public class ShoppingCart<T> where T : Product
{
    private Dictionary<T, int> _cartItems = new Dictionary<T, int>();
    public void AddNameToCart(T product, int quantity)
    {

    }
    public double CalculateTotal(Func<T, double, double> discountCalculator = null)
    {
        double total = 0;
        foreach (var items in _cartItems)
        {
            total += (double)(items.Key.Price * items.Value);
            
        }

            return total;
    }
     public List<T> GetTopExpensiveItems(int n)
    {
        var item = _cartItems.OrderByDescending(x=> x.Key.Price).Take(n).Select(x=> x.Key ).ToList();
       
        return item;

    }
    
}
