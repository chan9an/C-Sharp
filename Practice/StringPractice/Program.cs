using System;
using System.Reflection;
class Program
{
    static void Main(string[] args)
    {
        Type t = typeof(string);
        foreach (MethodInfo m in t.GetMethods())
        {
            System.Console.WriteLine(m);
        }
    }
    
}