using System;

namespace CustomerPropertyDemo;

class PrimeCustomer : Customer
{
    public List<Orders> MyPrimeOrders
    {
        set
        {
            MyPrimeOrders = value;
        }    
    }
    

}
