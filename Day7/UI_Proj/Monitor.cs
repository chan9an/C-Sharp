using System;
using System.Collections;
using BL_Proj;

namespace UI_Proj;

 class Monitor :Product
    {
        public Monitor(string str) : base(str)
        {
        Stack ns = new Stack();
            
        }
        public string Parts
        {
            get
            {
                return Ingridents;
            }
        }
        
    }
