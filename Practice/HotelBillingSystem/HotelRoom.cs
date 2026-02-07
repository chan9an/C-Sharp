using System;

namespace HotelBillingSystem;

public class HotelRoom : IRooms
{
    #region Fields
      string _roomtype;
      double _ratePerNight;
      string _guestName;

    #endregion
    public string RoomType{set;get;}
    public string GuestName{get;set;}
    public double RatePerNight{get;set;}

    public int calculateMembershipYears(int joiningYear)
    {
    return 2026 - joiningYear;
    }

  public double calculateTotalBill(int nightsStayed, int joiningYear)
  {
    double totalBill = nightsStayed * _ratePerNight;
    int currentYears = calculateMembershipYears(joiningYear);
    if (currentYears > 3)
    {
      totalBill = totalBill - totalBill / 10;
    }

  
    return totalBill;
    }
}
