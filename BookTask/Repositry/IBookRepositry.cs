using BookTask.Models;

namespace BookTask.Repositry
{
    public interface IBookRepositry
    {
        IEnumerable<Book> GetAllBooks();
        Book GetBookById(int id);
        int AddBook(Book book);
        int UpdateBook(Book book);
        int DeleteBook(int id);
        IEnumerable<Book> SearchBooks(string searchTerm);
    }
}
