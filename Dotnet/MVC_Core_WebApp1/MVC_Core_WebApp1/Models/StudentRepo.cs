using System.Linq;
namespace MVC_Core_WebApp1.Models
{
    public class StudentRepo : IRepo<Student>
    {
        private List<Student> studList = new List<Student>
{
    new Student { Name = "Arya", RollNo = 101, Age = 23, Address = "Pune" },
    new Student { Name = "Champ", RollNo = 102, Age = 24, Address = "Chd" }
};

        public bool AddData(Student obj)
        {
            bool flag = false;
            if (obj != null)
            {
                studList.Add(obj);
                flag = true;
            }
            else
            {
                throw new NullReferenceException("Student Already There");
            }
               return flag;
        }

        public bool DeleteData(int id)
        {
            bool flag = false;
            Student sObj = studList.Find(s => s.RollNo == id);
            if (sObj != null)
            {
                studList.Remove(sObj);
                flag = true;
            }
            
            return flag;
        }

        public List<Student> ShowAllData()
        {
            return studList;
        }

        public Student ShowDetailsByID(int id)
        {
            Student sObj = studList.Find(s => s.RollNo == id);
            return sObj;
        }

        public bool UpdateData(int id, Student obj)
        {
            bool flag = false;
            Student sObj = studList.Find(s => s.RollNo == id);
            if (sObj != null)
            {
                sObj.Name=obj.Name;
                sObj.Address=obj.Address;
                sObj.Age=obj.Age;
                flag = true;
            }
           
            return flag;
        }
    }
}