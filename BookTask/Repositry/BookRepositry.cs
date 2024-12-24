using BookTask.Data;
using BookTask.Models;

namespace BookTask.Repositry
{
    public class BookRepositry : IBookRepositry
    {
        private readonly ApplicationDbContext db;
        public BookRepositry(ApplicationDbContext db)
        {
            this.db = db;   
        }
        public int AddBook(Book book)
        {
            db.Books.Add(book);
            int result = db.SaveChanges();
            return result;
        }

        public int DeleteBook(int id)
        {
            int res = 0;
            var result = db.Books.Where(b => b.Id == id).FirstOrDefault();
            if (result != null)
            {
                db.Books.Remove(result);
                res = db.SaveChanges();
            }
            return res;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return db.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            var result = db.Books.Where(b => b.Id == id).SingleOrDefault();
            return result;
        }

        public int UpdateBook(Book book)
        {
            int res = 0;
            var result = db.Books.Where(b => b.Id == book.Id).SingleOrDefault();
            if (result != null)
            {
                result.Title = book.Title;
                result.Author = book.Author;
                result.Genre = book.Genre;
                result.PublishedYear = book.PublishedYear;
                res = db.SaveChanges();
            }
            return res;
        }
        public IEnumerable<Book> SearchBooks(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return db.Books.ToList();

            string lowerCaseSearchTerm = searchTerm.ToLower();
            return db.Books
                .Where(b => b.Title.ToLower().Contains(lowerCaseSearchTerm) || b.Author.ToLower().Contains(lowerCaseSearchTerm))
                .ToList();
        }
    }
}
