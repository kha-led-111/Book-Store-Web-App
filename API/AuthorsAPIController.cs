using Bookstore_Ecommerce.Data;
using Bookstore_Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Ecommerce.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsAPIController : ControllerBase
    {
        private BookEcContext _context;
        public AuthorsAPIController(BookEcContext context)
        {
            _context = context;
        }

        //api/author/getall
        //Get:api/author
        [HttpGet]
        public IActionResult Getall()
        {

            List<Author> allauthors = _context.author.ToList();
            return Ok(allauthors);

        }
        //api/author/getbyid
        //Get:api/author/{id}
        [HttpGet("{id}")]
        public IActionResult GetID(int id)
        {

            var IDAuthor = _context.author.FirstOrDefault(b => b.Id == id);
            return Ok(IDAuthor);

        }
        //api/author/add
        //Post:api/author
        [HttpPost]
        public async Task<IActionResult> Add(Author author)
        {
            _context.Add(author);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetID), new { id = author.Id }, author);
        }

        //api/author/delete
        //Delete:api/author/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var authour = await _context.author.FindAsync(id);
            if (authour == null)
            {
                return NotFound();
            }
            else
            {
                _context.author.Remove(authour);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
        //api/author/update
        //Put:api/author/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Author author)
        {
            //عشان اشوف هكمل التعديل ولا لا
            if (id != author.Id)
            {
                return BadRequest("ID don't match");

            }
            _context.Entry(author).State = EntityState.Modified;//عشان اعرف الefcoreان في تغير
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
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



        //to ensure if author exist or not
        private bool isExit(int id)
        {
            return _context.author.Any(b => b.Id == id);
        }

    }
}

