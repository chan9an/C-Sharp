using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIsconnectedArchi
{

    /// <summary>
    /// Entity Class
    /// </summary>

    public class Product
    {
        int prodID;
        string name;
        string category;
        int price;
        string desc;

        public int ProdID
        {
            get { return prodID; }
            set
            {
                if (value >= 1 && value <= 999)
                    prodID = value;
                else
                    throw new MyCustomException("Invalid Product ID");
            }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public string Description
        {
            get { return desc; }
            set { desc = value; }
        }
    }

}
