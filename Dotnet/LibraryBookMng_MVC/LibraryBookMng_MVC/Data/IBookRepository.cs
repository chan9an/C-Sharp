using LibraryBookMng_MVC.Models;

namespace LibraryBookMng_MVC.Data
{
    public interface IBookRepository
    {
        public List<Book> GetAllBooks();
        public Book GetBook(int id);
        public bool AddBook(Book book);
        public bool DeleteBook(int id);



    }
}
