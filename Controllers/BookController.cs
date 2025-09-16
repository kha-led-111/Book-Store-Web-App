using Bookstore_Ecommerce.Data;
using Bookstore_Ecommerce.Data.Service;
using Bookstore_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Ecommerce.Controllers
{

    public class BookController : Controller
    {
        private IBookService _service;
        private BookEcContext _context;

        public BookController(IBookService service, BookEcContext context)
        {
            _service = service;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var AllBooks =await _context.books.Include(b => b.Author).Include(b => b.Publish_house).ToListAsync();
            return View(AllBooks);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Title = "Create new BOOK";
            //هجيب ال الؤلف ف هيئه list وابعته لل view
            var Authors=await _context.author.ToListAsync();
            //publish house
            var Publishs=await _context.publish_house.ToListAsync();

            //عشان ابعته لل view لازم اعمل view bag
            ViewBag.authors = new SelectList(Authors, "Id", "fullname");
            ViewBag.publish = new SelectList(Publishs, "Id", "Fullname");

            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Image,Book_Name,Description,Publish_data,price,Category,AuthorId,Publish_houseId")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.authors = new SelectList(await _context.author.ToListAsync(),"Id", "fullname", book.AuthorId);
            ViewBag.publish = new SelectList(await _context.publish_house.ToListAsync(), "Id", "Fullname", book.Publish_houseId);
            // في حالة فيه خطأ في الفاليديشن لازم نرجّع القائمة تاني
            //ViewBag.AuthorList = new SelectList(_context.author, "Id", "Name", book.AuthorId);
            return View(book);
           
        }
        
        public async Task<IActionResult> Details(int id)
        {
            var AuthorId = await _service.GetbyId(id);
            if (AuthorId == null)
            {
                return View("Empty");
            }
            else
            {
                return View(AuthorId);
            }

        }
        public async Task<IActionResult> Edit(int id)
        {
            var book = await _service.GetbyId(id);
            if (book == null)
                return View("Empty"); // أو NotFound()

            // تأكد من أن ViewBag متجهزين
            ViewBag.Authors = new SelectList(_context.author, "Id", "Name", book.AuthorId);
            ViewBag.PublishHouses = new SelectList(_context.publish_house, "Id", "Name", book.Publish_houseId);

            return View(book);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Image,Book_Name,Description,Publish_data,price,Category,AuthorId,Publish_houseId")] Book book)
        {
            if (!ModelState.IsValid)
            {
                // لو فيه Validation Errors
                ViewBag.Authors = new SelectList(_context.author, "Id", "Name", book.AuthorId);
                ViewBag.PublishHouses = new SelectList(_context.publish_house, "Id", "Name", book.Publish_houseId);
                return View(book);
            }

            var existing = await _service.GetbyId(id);
            if (existing == null)
                return View("Empty");

            await _service.UpdateAsync(id, book);
            return RedirectToAction(nameof(Index));
        }

       
        public async Task<IActionResult> Delete(int id)
        {
            var bookdelete = await _service.GetbyId(id);
            if (bookdelete == null) { return View("Empty"); }
            else
            {
                return View(bookdelete);
            }

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var bookdelete = await _service.GetbyId(id);
            if (bookdelete == null) { return View("Empty"); }
            else
            {
                await _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }

        }
    }
}


