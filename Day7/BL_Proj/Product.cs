using System;

namespace BL_Proj;

public class Product
{
    #region Properties
    public int ProductID { get; set; }
    public string Name { get; set; }
    protected string Ingridents { get; set; }
    private int MFCost;
    internal string BatchNo { get; set; }
    protected internal string Lot { get; set; }
    

    #endregion

}
