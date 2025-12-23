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
List<Product> products= new List<Product>()
{
    new Product(){ ProdID = 102, name = "Phone", price = 8000 },
    new Product(){ ProdID = 102, name = "Phone", price = 8000 },
    new Product(){ ProdID = 102, name = "Phone", price = 8000 },
    new Product(){ ProdID = 102, name = "Phone", price = 8000 },
    new Product(){ ProdID = 102, name = "Phone", price = 8000 },
    new Product(){ ProdID = 102, name = "Phone", price = 8000 },
    new Product(){ ProdID = 102, name = "Phone", price = 8000 }
    ;
}

