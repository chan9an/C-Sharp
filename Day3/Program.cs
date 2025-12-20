using System;

namespace Day3
{
    internal class Program
    {
        // Method to swap two integers using ref keyword
        // ref allows changing the original values (Call by Reference)
        static void SwapMe(ref int x, ref int y)
        {
            int temp = x;  // store value of x
            x = y;         // assign y to x
            y = temp;      // assign temp (old x) to y
        }
        public int AddToCart(params int[] prices){
            int total = 0;
            for each(int item in prices){

            }
        }

        static void Main(string[] args)
        {
            // ---------------- POLYMORPHISM ----------------
            // Method Overloading example (Compile-time polymorphism)

            Person personObj = new Person(); // Named object

            personObj.Display(100);           // int version
            personObj.Display(100.25f);       // float version
            personObj.Display("LPU");         // string version
            personObj.Display(new Employee()); // object version (anonymous object)

            // ---------------- TYPE CASTING ----------------

            int x = 100;        // int value
            long z = x;         // Implicit casting (int → long)

            // short y = x;     // ❌ Error: implicit conversion not allowed
            short y = (short)x; // Explicit casting (int → short)

            // ---------------- BOXING & UNBOXING ----------------

            int num1 = 120;
            object op = num1;       // Boxing (value type → reference type)
            int num2 = (int)op;     // Unboxing (reference type → value type)

            // ---------------- SWAPPING ----------------

            // ❌ This will NOT swap values (Call by Value)
            SwapMe(ref num1, ref num2);

            Console.WriteLine("After Swapping:");
            Console.WriteLine("num1: {0}, num2: {1}", num1, num2);
            Program pObj = new Program();
            pObj.AddToCart(10,20);
            pObj.AddToCart(10,20,30,40,50);
            

            
        }
    }
}