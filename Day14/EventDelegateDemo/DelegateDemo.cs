using System;

namespace EventDelegateDemo;

    //Multicast delegate
    
    public delegate void GreetMsg(string msg);
    //Unicast delegate
    public delegate int Calculation(int num1, int num2);



public class DelegateDemo
{
    public static void DelegateDemoMain()
    {
        Tamil tamilObj = new Tamil();
        GreetMsg greetInTamil = new GreetMsg(tamilObj.WelcomeMsg);
        
        greetInTamil("Alok");


    }

}
