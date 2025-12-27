// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using Day4.Project;

/*
MathClass m1 = new MathClass();//Alok_add 
MathClass m2 = new MathClass();//Riya_add_sub
MathClass m3 = new MathClass();//All
*/
/* IAdd m1 = new MathClass();//Alok_add 
IAddSub m2 = new MathClass();//Riya_add_sub
IAll m3 = new MathClass();//All */

//Approach 1
Product pObj = new Product();
pObj.ProdID = 101;
pObj.name = "Camera";
pObj.price = 10000;


//Approach 2 Object init
Product pObj1 = new Product() { ProdID = 102, name = "Phone", price = 8000 };
List<Product> products = new List<Product>()
{
    new Product(){ ProdID = 103, name = "Laptop", price = 50000 },
    new Product(){ ProdID = 104, name = "Tablet", price = 20000 },
    new Product(){ ProdID = 105, name = "Smartwatch", price = 15000 },
    new Product(){ ProdID = 106, name = "Headphones", price = 5000 },
    new Product(){ ProdID = 107, name = "Gaming Console", price = 30000 },
    new Product(){ ProdID = 108, name = "Smart TV", price = 40000 },
    new Product(){ ProdID = 109, name = "Bluetooth Speaker", price = 7000 }
};

foreach (var items in products)
{
    System.Console.WriteLine("Products");
}