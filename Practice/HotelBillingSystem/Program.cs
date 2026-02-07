namespace HotelBillingSystem;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter Deluxe Room Details: ");
        Console.WriteLine("Guest Name: ");
        string dGuestname = Console.ReadLine();
        int dRatePerNight = Int32.Parse(Console.ReadLine());
        int dNightsStayed = Int32.Parse(Console.ReadLine());
        int dJoiningYear = Int32.Parse(Console.ReadLine());

        Console.WriteLine("Enter Suite Room Details: ");
        Console.WriteLine("Guest Name: ");
        string sGuestname = Console.ReadLine();
        int sRatePerNight = Int32.Parse(Console.ReadLine());
        int sNightsStayed = Int32.Parse(Console.ReadLine());
        int sJoiningYear = Int32.Parse(Console.ReadLine());

        HotelRoom objHotelRoom = new HotelRoom();


    }
}