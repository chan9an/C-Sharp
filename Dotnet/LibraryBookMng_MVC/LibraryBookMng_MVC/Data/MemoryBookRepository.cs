using LibraryBookMng_MVC.Models;

namespace LibraryBookMng_MVC.Data
{
    
    public class MemoryBookRepository : IBookRepository
    {
        private static List<Book> bookList = new List<Book>() {
        new Book() {Author="Arti Thakur" , BookId=1,Price=2000,Title="Harry Potty and Chamber of Secrets"}, 
        new Book() {Author="Megha Thakur" , BookId=2,Price=2100,Title="The Song of Ice And Fire"},
        new Book() {Author="Parth Sharma" , BookId=4,Price=1900,Title="East Of Eden"},
         new Book() {Author="Mr. Chandan Singh Rajput" , BookId=3,Price=1700,Title="One Piece"},
         new Book() {Author="Mr. Nisha Agarwal" , BookId=5,Price=1200,Title="The Island of Missing Trees"}
   };


        public bool AddBook(Book book)
        {
            throw new NotImplementedException();
        }

        public bool DeleteBook(int id)
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Book GetBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}
