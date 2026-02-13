using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;

namespace ArcDemo
{
    public class StudentDAL
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        public StudentDAL()
        {
            con = new SqlConnection("Server=.\\sqlexpress;Integrated Security=True;Database=LPU_DB;TrustServerCertificate=True;");
        }

        public List<Student> ShowAllStudents()
        {
            List<Student> studList = new List<Student>();

            try
            {
                con.Open();

                cmd = new SqlCommand("Select * from StudentInfo", con);
                sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Student sObj = new Student()
                    {
                        RollNo = Convert.ToInt32(sdr[0]),
                        Name = sdr[1].ToString(),
                        Address = sdr[3].ToString(),
                        PhoneNo = sdr[5].ToString()
                    };

                    studList.Add(sObj);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

            return studList;
        }

        public List<Student> SearchByName(string name)
        {
            List<Student> studList = new List<Student>();

            try
            {
                con.Open();

                cmd = new SqlCommand("Select * from StudentInfo where Name = @Name", con);
                cmd.Parameters.AddWithValue("@Name", name);

                sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    Student sObj = new Student()
                    {
                        RollNo = Convert.ToInt32(sdr[0]),
                        Name = sdr[1].ToString(),
                        Address = sdr[3].ToString(),
                        PhoneNo = sdr[5].ToString()
                    };

                    studList.Add(sObj);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

            return studList;
        }


        public Student SearchByID(int id)
        {
            Student student = null;

            try
            {
                con.Open();

                cmd = new SqlCommand("Select * from StudentInfo where RollNo = @id", con);
                cmd.Parameters.AddWithValue("@id", id);

                sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    student = new Student()
                    {
                        RollNo = Convert.ToInt32(sdr[0]),
                        Name = sdr[1].ToString(),
                        Address = sdr[2].ToString(),
                        PhoneNo = sdr[3].ToString()
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }

            return student;
        }

        public bool AddStudent(Student student)
        {

             bool flag = false;
            con.Open();
            SqlParameter[] param = new SqlParameter[5];

            for(int i =0; i < param.Length; i++)
            {
                param[i] = new SqlParameter();

            }

            param[0].ParameterName = "@RollNo";
            param[0].Value=student.RollNo;
            param[1].ParameterName = "@Name";
            param[1].Value = student.Name;
            param[2].ParameterName = "@Age";
            param[2].Value = student.Age;
            param[3].ParameterName = "@Addr";
            param[3].Value = student.Address;
            param[4].ParameterName = "@PhoneNo";
            param[4].Value = student.PhoneNo;
            cmd = new SqlCommand();
            cmd.CommandText = $"Insert into StudentInfo(RollNo,Name,Age,PerAddress,PhoneNo) values({param[0].ParameterName},{param[1].ParameterName},{param[2].ParameterName},{param[3].ParameterName},{param[4].ParameterName})";
            cmd.Connection = con;
            cmd.Parameters.AddRange(param);
            int rows =cmd.ExecuteNonQuery();
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }



        }
    }
}
