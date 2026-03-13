
namespace First_WebAPI_Demo.Models.Repo
{
    public class StudentRepos : IRepos<Student>
    {
        public static List<Student> studList = null;

        public StudentRepos() { 
            if(studList== null) studList = new List<Student>() { new Student()
            {
                City="Jalandhar",Name="Riya Thakur",RollNo=101,PhoneNo="9855678654"
            } };
        }
        public bool Add(Student item)
        {
            bool flag = false;
            if(studList!= null)
            {
                studList.Add(item);
                flag=true;
            }
            return flag;
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Student Get(int id)
        {
           Student student = studList.Find(x => x.RollNo == id);//if we have primary Key record we use
                                                                //Find like roll number but if we have to 
                                                                //find name adress where can be multiple use 
                                                                // where keyword
            if (student != null)
            {
                return student;
            }
            else
            {
                throw new Exception("Student Record Not Available");
            }
        }

        public ICollection<Student> GetAll()
        {
            return studList;
        }

        public bool Update(int id, Student item)
        {
            //throw new NotImplementedException();
            bool flag =false;
            Student existStud = studList.Find(s => s.RollNo == id);
            if (existStud != null && item !=null)
            {
                existStud.Name=item.Name;
                existStud.City=item.City;
                existStud.PhoneNo=item.PhoneNo;

            }
            return flag;
        }
    }
}
