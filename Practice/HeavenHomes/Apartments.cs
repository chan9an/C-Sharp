using System;
using System.Collections;
namespace HeavenHome;

internal class Apartment{
  #region Fields
  private Dictionary<string,double> apartmentDetailsMap;
  #endregion
  
  #region properties
  public Dictionary<string,double> partmentDetailsMap{get;set;}
  #endregion
  
  #region methods
  public void addApartmentDetails(string apartmentNumber,double rent )
  {
    apartmentDetailsMap.Add(apartmentNumber,rent);
    
  }

  


  #endregion 
  





}
