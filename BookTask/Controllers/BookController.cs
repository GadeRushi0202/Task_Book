using BookTask.Models;
using BookTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookTask.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookServices services;
        public BookController(IBookServices services)
        {
            this.services = services;
        }

        // GET: BookController
        /*public ActionResult Index(string searchTerm)
        {
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                var searchResult = services.SearchBooks(searchTerm);
                return View(searchResult);
            }

            var result = services.GetAllBooks();
            return View(result);
        }*/
        public IActionResult Index(string searchTerm, string sortOrder)
        {
            var books = services.SearchBooks(searchTerm);

            // Default sorting: Title ascending
            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title).ToList();
                    break;
                case "year_asc":
                    books = books.OrderBy(b => b.PublishedYear).ToList();
                    break;
                case "year_desc":
                    books = books.OrderByDescending(b => b.PublishedYear).ToList();
                    break;
                default: // Default to Title ascending
                    books = books.OrderBy(b => b.Title).ToList();
                    break;
            }

            ViewBag.CurrentSort = sortOrder;
            ViewBag.TitleSortParam = string.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewBag.YearSortParam = sortOrder == "year_asc" ? "year_desc" : "year_asc";

            return View(books);
        }


        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            var result = services.GetBookById(id);
            return View(result);
        }

        // GET: BookController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book book)
        {
            try
            {
                int res = services.AddBook(book);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {
            var result = services.GetBookById(id);
            return View(result);
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            try
            {
                int res = services.UpdateBook(book);
                if (res >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            var result = services.GetBookById(id);
            return View(result);
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int result = services.DeleteBook(id);
                if (result >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }
    }
}
