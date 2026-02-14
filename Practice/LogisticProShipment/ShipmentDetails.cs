using System;
namespace LogisticProShipment
{
  public class ShipmentDetails : Shipment{
    public bool ValidateShipmentCode(){
      string testString = ShipmentCode;
      if(testString.Length == 7){
        if(testString[0]=='G' && testString[1]=='C' && testString[2]=='#'){
          for (int i=3; i < 7;i++)
          {
            if(!char.IsDigit(testString[i])){
              return false;
            }
              
          }
          return true;
        }
      }
      return false;
    }
    public double CalculateTotalCost(double RatePerKg){
       double total = Weight/RatePerKg + Math.Sqrt(StorageDays);
      return Math.Round(total,2);
    }


  }
    
}
