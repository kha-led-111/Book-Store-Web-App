using Bookstore_Ecommerce.Data.Service;
using Bookstore_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore_Ecommerce.Controllers
{
    public class ShopController : Controller
    {
      
            private IShopService _service;
        public ShopController(IShopService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var shop = _service.Getall();
            return View(shop);
        }
        public async Task<IActionResult> Create()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Profile_picture,fullname,Bio")] Shop shop)
        {
            if (ModelState.IsValid) { return View(shop); }
            _service.Add(shop);
            return RedirectToAction(nameof(Index));

        }
        public async Task<IActionResult> Details(int id)
        {
            var shopID = await _service.GetbyId(id);
            if (shopID == null)
            {
                return View("Empty");
            }
            else
            {
                return View(shopID);
            }

        }
        public async Task<IActionResult> Edit(int id)
        {
            var shopedit = await _service.GetbyId(id);
            if (shopedit == null) { return View("Empty"); }
            else
            {
                return View(shopedit);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Shoplogo,Name,Location")] Shop shop)
        {
            var shopedit = await _service.GetbyId(id);
            if (shopedit == null) { return View("Empty"); }
            else
            {
                await _service.UpdateAsync(id, shop);
                return RedirectToAction(nameof(Index));
            }
        }
        public async Task<IActionResult> Delete(int id)
        {
            var shopdelete = await _service.GetbyId(id);
            if (shopdelete == null) { return View("Empty"); }
            else
            {
                return View(shopdelete);
            }

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int id)
        {
            var shopdelete = await _service.GetbyId(id);
            if (shopdelete == null) { return View("Empty"); }
            else
            {
                await _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }

        }
    }
}
    
