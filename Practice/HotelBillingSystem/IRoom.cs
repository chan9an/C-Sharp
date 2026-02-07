using System;
using System.ComponentModel;

namespace HotelBillingSystem;

public interface IRooms
{
    public double calculateTotalBill(int nightsStayed, int joiningYear);
    public int calculateMembershipYears(int joiningYear);


}
