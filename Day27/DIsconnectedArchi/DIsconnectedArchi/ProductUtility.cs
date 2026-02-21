using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIsconnectedArchi
{
    


    public class ProductUtility : IProductRepo 
    {

        IDbConnection con;
        SqlDataAdapter adap1;
        DataSet ds;

        public ProductUtility()
        {
            con = new SqlConnection();
            con.ConnectionString = "Server=.;Integrated Security=True;Database=Lpu_Db;TrustServerCertificate=true";
        }
        bool IRepo<Product>.AddData(Product obj)
        {
            throw new NotImplementedException();
        }

        bool IRepo<Product>.DeleteData(int id)
        {
            throw new NotImplementedException();
        }

        List<Product> IProductRepo.GetTop3BudgetProduct()
        {
            throw new NotImplementedException();
        }

        List<Product> IProductRepo.GetTop3CostlyProduct()
        {
            throw new NotImplementedException();
        }

        Product IRepo<Product>.SearchByID(int id)
        {
            throw new NotImplementedException();
        }

        List<Product> IRepo<Product>.ShowAll()
        {
            List<Product> list = new List<Product>();

            using (SqlConnection con = new SqlConnection(
                "Server=localhost\\sqlexpress;Integrated Security=True;Database=Lpu_Db;TrustServerCertificate=true"))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT ProdID, Name, Category, Price, [Desc] FROM Products", con);

                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    list.Add(new Product
                    {
                        ProdID = Convert.ToInt32(dr["ProdID"]),
                        Name = dr["Name"].ToString(),
                        Category = dr["Category"].ToString(),
                        Price = Convert.ToInt32(dr["Price"]),
                        Description = dr["Desc"].ToString()
                    });
                }
            }

            return list;
        }



        List<Product> IProductRepo.ShowAllProductByCategory(int catID)
        {
            throw new NotImplementedException();
        }

        List<Product> IProductRepo.SortProductByPriceAsc()
        {
            throw new NotImplementedException();
        }

        List<Product> IProductRepo.SortProductByPriceDesc()
        {
            throw new NotImplementedException();
        }

        bool IRepo<Product>.UpdateData(int id, Product obj)
        {
            throw new NotImplementedException();
        }

        public DataTable GetAllData()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(
                "Server=localhost\\SQLEXPRESS;Integrated Security=True;Database=Lpu_Db;TrustServerCertificate=true"))
            {
                adap1 = new SqlDataAdapter("SELECT * FROM Products", con);
                adap1.Fill(dt);
            }

            return dt;
        }

    }
}
