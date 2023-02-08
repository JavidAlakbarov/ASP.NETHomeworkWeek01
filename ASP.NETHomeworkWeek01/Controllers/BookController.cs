using ASP.NETHomeworkWeek01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NETHomeworkWeek01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public static List<Book> _books = new List<Book>();

        [HttpPost("Create a Book")]
        public Book createBook(Book book)
        {
            _books.Add(book);
            return book;
        }

        [HttpGet("Get all Books")]
        public List<Book> getAll()
        {
            return _books;
        }

        [HttpGet("Get a Book by ID")]
        public IActionResult getBookId(int ID)
        {
            foreach(var book in _books)
            {
                var bookExists = _books.FirstOrDefault(x => x.ID == ID);
                if (bookExists != null)
                {
                    return Ok(bookExists);
                }
            }
            return NotFound("Can't find a book");
        }

        [HttpPut("Update a Book")]
        public Book UpdateBook(int id,Book book)
        {
            var bookExists = _books.FirstOrDefault(x => x.ID == id);
            bookExists.ID = book.ID;
            bookExists.BookName = book.BookName;
            bookExists.Price = book.Price;
            bookExists.Category = book.Category;
            bookExists.Author = book.Author;
            return bookExists;
        }

        [HttpDelete("Delete a Book")]
        public IActionResult DeleteBook(int id)
        {
            foreach(var book in _books)
            {
                var bookExists = _books.FirstOrDefault(x => x.ID == id);
                //_books.Remove(bookExists);
                if (bookExists != null)
                {
                    _books.Remove(bookExists);
                    return Ok("Book id N: ("+  book.ID + " - " +book.BookName +") has been deleted!!!");
                }
            }
            return NotFound("Can't find a book for deleting!!!");
        }
    }
}
