using BookTask.Models;
using BookTask.Repositry;

namespace BookTask.Services
{
    public class BookServices : IBookServices
    {
        private readonly IBookRepositry repo;
        public BookServices(IBookRepositry repo)
        {
            this.repo = repo;
        }
        public int AddBook(Book book)
        {
            return repo.AddBook(book);
        }

        public int DeleteBook(int id)
        {
            return repo.DeleteBook(id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return repo.GetAllBooks();
        }

        public Book GetBookById(int id)
        {
            return repo.GetBookById(id);
        }

        public IEnumerable<Book> SearchBooks(string searchTerm)
        {
            return repo.SearchBooks(searchTerm);    
        }

        public int UpdateBook(Book book)
        {
            return repo.UpdateBook(book);
        }
    }
}
