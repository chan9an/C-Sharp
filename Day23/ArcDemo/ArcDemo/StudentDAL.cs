using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcDemo
{
    public class StudentDAL
    {

        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        public StudentDAL()
        {
            string conStr = "Data Source=.\\sqlexpress;Initial Catalog=LPU_DB;Integrated Security=True;Trust Server Certificate=True"; // old version mein integrated security = true kaam nhi krta usmein ssip kaam ata hai
            con = new SqlConnection();
            con.ConnectionString = "Server=.\\sqlexpress;Integrated Security=True;Database=LPU_DB;TrustServerCertificate=True;";
        }


        public List<Student> ShowAllStudents()
        {
            List<Student> studList = null;
            //Code for connected Architecture below

            try
            {
                con.Open();
                cmd = new SqlCommand();
                cmd.CommandText = "Select * from StudentInfo";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                sdr = cmd.ExecuteReader();
                DataTable myDt = new DataTable();
                //Converting the database row into the list so that we cn access
                foreach(DataRow row in sdr)
                {
                    Student sObj = new Student()
                    {
                        RollNo = Convert.ToInt32(row[0].ToString()),
                        Name = row[1].ToString(),
                        Address = row[2].ToString(),
                        PhoneNo = row[4].ToString(),



                    };
                    if (sObj != null)
                    {
                        studList.Add(sObj);

                    }

                }
                myDt.Load(sdr);

            }
            catch (Exception e)
            {
                throw e;

            }

            finally
            {
                con.Close();
            }

            return studList;
        }



        public List<Student> SearchByName(string Name)
        {
            List<Student> studList = null;

            return studList;
        }


        public Student SearchByID(int ID)
        {
            Student student = null;


            return student;

        }



    }
}
