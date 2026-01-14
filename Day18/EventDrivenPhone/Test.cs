using System;
using System.Runtime.InteropServices;

namespace EventDrivenPhone;

public class Test
{
    static void Main()
    {
        PhoneCall objPhoneCall = new PhoneCall();
        objPhoneCall.MakeAPhoneCall(true);
        System.Console.WriteLine(objPhoneCall.Message);
        objPhoneCall.MakeAPhoneCall(false);
        System.Console.WriteLine(objPhoneCall.Message);
    }
}
