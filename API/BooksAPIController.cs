using Bookstore_Ecommerce.Data;
using Bookstore_Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Ecommerce.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksAPIController : ControllerBase
    {
        private BookEcContext _context;
        public BooksAPIController(BookEcContext context)
        {
            _context = context;
        }

        //api/book/getall
        //Get:api/book
        [HttpGet]
        public IActionResult Getall() {

            List<Book> allbooks = _context.books.Include(b => b.Author)
                                   .Include(b => b.Publish_house).ToList();
            return Ok(allbooks);

        }
        //api/book/getbyid
        //Get:api/book/{id}
        [HttpGet("{id}")]
        public IActionResult GetID(int id) {

            var IDbook = _context.books.Include(b => b.Author).Include(b => b.Publish_house).FirstOrDefault(b => b.Id == id);
            return Ok(IDbook);

        }
        //api/book/add
        //Post:api/book
        [HttpPost]
        public async Task<IActionResult> Add(Book book)
        {
            _context.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetID), new { id = book.Id }, book);
        }

        //api/book/delete
        //Delete:api/book/id
        [HttpDelete("{id}")]
        public async Task<IActionResult>Delete(int id)
        {
            var book = await _context.books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                _context.books.Remove(book);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
        //api/book/update
        //Put:api/book/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,Book book)
        {
            //عشان اشوف هكمل التعديل ولا لا
            if (id != book.Id)
            {
                return BadRequest("ID don't match");

            }
            _context.Entry(book).State = EntityState.Modified;//عشان اعرف الefcoreان في تغير
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!isExit(id))
                {
                    return NotFound();
                }
                else
                {

                    throw;
                }
            
            }
            return NoContent();

        }
     


            //to ensure if books exist or not
        private bool isExit(int id)
        {
            return _context.books.Any(b => b.Id == id);
        }

    }
}
