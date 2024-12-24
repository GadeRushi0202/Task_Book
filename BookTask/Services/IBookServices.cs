using BookTask.Models;

namespace BookTask.Services
{
    public interface IBookServices
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        int AddBook(Book book);
        int UpdateBook(Book book);
        int DeleteBook(int id);
        IEnumerable<Book> SearchBooks(string searchTerm);
    }
}
