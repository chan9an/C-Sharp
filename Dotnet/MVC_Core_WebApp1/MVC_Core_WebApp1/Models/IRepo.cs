namespace MVC_Core_WebApp1.Models
{
    public interface IRepo<T>
    {
        public bool AddData(T obj);
         public bool UpdateData(int id,T obj);
        public bool DeleteData(int id);
        public List<T> ShowAllData();
        public T ShowDetailsByID(int id);
        

    }
}