using Bookstore_Ecommerce.Data;
using Bookstore_Ecommerce.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Ecommerce.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class publish_HouseAPIController : ControllerBase
    {
        
        
            private BookEcContext _context;
        public publish_HouseAPIController(BookEcContext context)
            {
                _context = context;
            }

        //api/Publishing_House/getall
        //Get:api/Publishing_House
        [HttpGet]
            public IActionResult Getall()
            {

                List<Publishing_House> allHouse = _context.publish_house.ToList();
                return Ok(allHouse);

            }
        //api/Publishing_House/getbyid
        //Get:api/Publishing_House/{id}
        [HttpGet("{id}")]
            public IActionResult GetID(int id)
            {

                var IDPublish = _context.publish_house.FirstOrDefault(b => b.Id == id);
                return Ok(IDPublish);

            }
        //api/Publishing_House/add
        //Post:api/Publishing_House
        [HttpPost]
            public async Task<IActionResult> Add(Publishing_House publish)
            {
                _context.Add(publish);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetID), new { id = publish.Id }, publish);
            }

        //api/Publishing_House/delete
        //Delete:api/Publishing_House/id
        [HttpDelete("{id}")]
            public async Task<IActionResult> Delete(int id)
            {
                var publish = await _context.publish_house.FindAsync(id);
                if (publish == null)
                {
                    return NotFound();
                }
                else
                {
                    _context.publish_house.Remove(publish);
                    await _context.SaveChangesAsync();
                    return NoContent();
                }
            }
        //api/Publishing_House/update
        //Put:api/Publishing_House/{id}
        [HttpPut("{id}")]
            public async Task<IActionResult> Update(int id, Publishing_House publish)
            {
                //عشان اشوف هكمل التعديل ولا لا
                if (id != publish.Id)
                {
                    return BadRequest("ID don't match");

                }
                _context.Entry(publish).State = EntityState.Modified;//عشان اعرف الefcoreان في تغير
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



        //to ensure if Publishing_House exist or not
        private bool isExit(int id)
            {
                return _context.publish_house.Any(b => b.Id == id);
            }

        }
    }

