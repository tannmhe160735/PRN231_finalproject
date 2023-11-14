using HE160735_NguyenMinhTan_Project_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HE160735_NguyenMinhTan_Project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        He160735NguyenMinhTanProjectContext _context;

        public BookController (He160735NguyenMinhTanProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            try
            {
                List<Book> books = _context.Books.ToList();
                if (books == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(books);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-books-by-id")]
        public IActionResult GetBookById(int id)
        {
            try
            {
                Book book = _context.Books.FirstOrDefault(b => b.BookId == id);
                if(book == null)
                {
                    return NotFound("Dont have any record with id " + id);
                }
                else
                {
                    return Ok(book);
                }
            }
            catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Get-books-by-user-id")]
        public IActionResult GetBookByUserId(int userId)
        {
            try
            {
                List<Book> books = _context.Books.Where(b => b.UserId == userId).ToList();
                if (books == null)
                {
                    return NotFound("Dont have any record with id " + userId);
                }
                else
                {
                    return Ok(books);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Filter-Book")]
        public IActionResult GetFilterBooks(string? name, string? phone, string? bookdate, string? booktime)
        {
            try
            {
                List<Book> books = _context.Books.ToList();
                if (!string.IsNullOrEmpty(name))
                {
                    books = books.Where(b => b.Name == name).ToList();
                }
                if (!string.IsNullOrEmpty(phone))
                {
                    books = books.Where(b => b.Phone == phone).ToList();
                }
                if (!string.IsNullOrEmpty(bookdate))
                {
                    DateTime datetime = DateTime.Parse(bookdate);
                    books = books.Where(b => b.BookDate == datetime).ToList();
                }
                if (!string.IsNullOrEmpty(booktime))
                {
                    books = books.Where(b => b.BookTime.Contains(booktime)).ToList();
                }
                if (books == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(books);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Add-book")]
        public IActionResult AddBook(Book book)
        {
            try
            {
                _context.Books.Add(book);
                _context.SaveChanges();
                return Ok("Add Book Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update-book")]
        public IActionResult UpdateGuestIdBook(int guestId, int userId)
        {
            try
            {
                Book book = _context.Books.FirstOrDefault(b => b.UserId == guestId);
                book.UserId = userId;
                _context.Books.Update(book);
                _context.SaveChanges();
                return Ok("Update Book Id Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Delete-book")]
        public IActionResult DeleteBook(int id) 
        {
            try
            {
                Book book = _context.Books.FirstOrDefault(b => b.BookId == id);
                _context.Books.Remove(book);
                _context.SaveChanges();
                return Ok("Delete Book Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
