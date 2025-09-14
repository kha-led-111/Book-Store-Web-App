using System.Reflection.Metadata.Ecma335;
using Bookstore_Ecommerce.Data;
using Bookstore_Ecommerce.Data.Service;
using Bookstore_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Ecommerce.Controllers
{
    public class AuthorController : Controller
    {
        private IAuthorService _service;
        public AuthorController(IAuthorService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var AllAuthors =  _service.Getall();
            return View(AllAuthors);
        }
        public async Task<IActionResult> Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Profile_picture,fullname,Bio")] Author author)
        {
            if (ModelState.IsValid) { return View(author); }
            _service.Add(author);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Details(int id)
        {
            var AuthorId= await _service.GetbyId(id);
            if (AuthorId == null) {
                return View("Empty");
            }
            else
            {
                return View(AuthorId);
            }

        }
        public async Task<IActionResult> Edit(int id) 
        {
            var AuthorEdit =await _service.GetbyId(id);
            if (AuthorEdit == null) { return View("Empty"); }
            else
            {
                return View(AuthorEdit);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Profile_picture,fullname,Bio")] Author author)
        {
            var AuthorEdit= await _service.GetbyId(id);
            if (AuthorEdit == null) { return View("Empty"); }
            else
            {
               await _service.UpdateAsync(id, author);
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<IActionResult>Delete(int id) 
        {
            var authordelete= await _service.GetbyId(id);
            if (authordelete == null) { return View("Empty"); }
            else
            {
                return View(authordelete);
            }
        
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var authordelete = await _service.GetbyId(id);
            if (authordelete == null) { return View("Empty"); }
            else
            {
                await _service.Delete(id);
                return RedirectToAction(nameof (Index));
            }

        }
    }
}
