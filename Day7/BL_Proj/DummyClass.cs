using System;

namespace BL_Proj;

class DummyClass
{
    public void DummyClassDisplay()
    {
        Product productObj = new Product();
        Toys la = new Toys();
        productObj.Lot = "Hello ";
        la.Lot = "HEY ";
        System.Console.WriteLine(la.Lot);
        System.Console.WriteLine(productObj.Lot);

        
                 
    }

}
