using Microsoft.EntityFrameworkCore;
namespace LibraryBookMng_MVC.Models
{
    public class BookDBContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
          =>optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=StudentPortalDb;Integrated Security=True;TrustServerCertificate=True");
        

    }
}
