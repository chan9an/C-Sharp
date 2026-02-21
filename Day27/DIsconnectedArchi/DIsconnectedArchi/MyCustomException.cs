using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIsconnectedArchi
{
    public class MyCustomException : ApplicationException
    {
        public MyCustomException(string msg) : base(msg)
        {
        }
    }

}
