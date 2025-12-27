using System;

namespace BL_Proj;

class Toys : Product
{
    public string Components
    {
        get
        {
            return Ingridents;
        }
        set
        {
            Ingridents = value;
        }
    }

}
