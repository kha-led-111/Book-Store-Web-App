using Bookstore_Ecommerce.Data;
using Bookstore_Ecommerce.Data.Service;
using Bookstore_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Ecommerce.Controllers
{
    public class Publishing_HouseController : Controller
    {
        private Ipublishing_HouseService _service;
        public Publishing_HouseController(Ipublishing_HouseService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var publishHouse = _service.Getall();
            return View(publishHouse);
        }
        public async Task<IActionResult> create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> create([Bind("Logo,Fullname,Bio")] Publishing_House newpublish)
        {
            if (ModelState.IsValid) {
                return View(newpublish);
            }
            else
            {
                _service.Add(newpublish);
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var publishdelete = await _service.GetbyId(id);
            if (publishdelete == null) { return View("Empty"); }
            else
            {
                return View(publishdelete);
               
            }
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult>ConfirmDlelet(int id)
        {
            var publishdelete = await _service.GetbyId(id);
            if (publishdelete == null) { return View("Empty"); }
            else
            {
                await _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }

        }
        public async Task<IActionResult> Details(int id)
        {
            var publishDetails = await _service.GetbyId(id);
            if (publishDetails == null) { return View("Empty"); }
            else { return View(publishDetails); }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var publishEdit = await _service.GetbyId(id);
            if (publishEdit == null) { return View("Empty"); }
            else { return View(publishEdit); }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("Id,Logo,Fullname,Bio")] Publishing_House edited)
        {
            var publishEdit= await _service.GetbyId(id);
            if (publishEdit == null) { return View("Empty"); }
            else {
                await _service.UpdateAsync(id, edited);
                return RedirectToAction(nameof(Index));        
            }


        }
    } 
}

