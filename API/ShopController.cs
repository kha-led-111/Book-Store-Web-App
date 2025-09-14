using Bookstore_Ecommerce.Data;
using Bookstore_Ecommerce.Data.Service;
using Bookstore_Ecommerce.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore_Ecommerce.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _service;

        public ShopController(IShopService service)
        {
            _service = service;
        }

        // GET: api/shop
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _service.Getall();
            return Ok(data);
        }

        // GET: api/shop/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var shop = await _service.GetbyId(id);
            if (shop == null)
                return NotFound();

            return Ok(shop);
        }

        // POST: api/shop
        [HttpPost]
        public async Task<IActionResult> Create(/*[FromBody]*/ Shop shop)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);

            await _service.Add(shop);
            return CreatedAtAction(nameof(GetById), new { id = shop.Id }, shop);
        }

        // PUT: api/shop/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] Shop shop)
        {
            if (id != shop.Id)
                return BadRequest("Id mismatch");

            await _service.UpdateAsync(id, shop);
            return NoContent();
        }

        // DELETE: api/shop/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var shop = await _service.GetbyId(id);
            if (shop == null)
                return NotFound();

            await _service.Delete(id);
            return NoContent();
        }
    }
    //[ApiController]
    //[Route("api/[controller]")]
    //public class ShopController : ControllerBase
    //{
    //    private IShopService _service;
    //    public ShopController(IShopService service)
    //    {
    //        _service = service;
    //    }
    //    [HttpGet]
    //    public IActionResult Index()
    //    {
    //        var data = _service.Getall();
    //        return Ok(data);
    //    }

    //    public async Task<IActionResult> Create()
    //    {
    //        return Ok();

    //    }
    //    [HttpPost]
    //    public async Task<IActionResult> Create([Bind("Shoplogo,Name,Location")] Shop shop)
    //    {
    //        if (ModelState.IsValid) { return Ok(shop); }
    //        _service.Add(shop);
    //        return RedirectToAction(nameof(Index));

    //    }
    //    [HttpGet("{id}")]
    //    public async Task<IActionResult> Details(int Id)
    //    {
    //        var Shopdetails = await _service.GetbyId(Id);
    //        if (Shopdetails == null)
    //        {
    //            return Ok("Empty");
    //        }
    //        else
    //        {
    //            return Ok(Shopdetails);
    //        }


    //    }
    //    [HttpPut("{id}")]
    //    public async Task<IActionResult> Edit(int Id)
    //    {
    //        var ShopEdit = await _service.GetbyId(Id);
    //        if (ShopEdit == null)
    //        {
    //            return Ok("Empty");
    //        }
    //        else
    //        {
    //            return Ok(ShopEdit);
    //        }
    //    }
    //    [HttpPost]
    //    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Shoplogo,Location")] Shop shop)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            return Ok(shop);
    //        }
    //        else
    //        {
    //            await _service.UpdateAsync(id, shop);
    //            return RedirectToAction(nameof(Index));
    //        }
    //    }
    //    [HttpDelete("{id}")]
    //    public async Task<IActionResult> Delete(int Id)
    //    {
    //        var ShopEdit = await _service.GetbyId(Id);
    //        if (ShopEdit == null)
    //        {
    //            return Ok("Empty");
    //        }
    //        else
    //        {
    //            return Ok(ShopEdit);
    //        }
    //    }

    //    [HttpPost, ActionName("Delete")]
    //    public async Task<IActionResult> DeleteConfirm (int id){
    //        var shopdetails=await _service.GetbyId(id);
    //        if (shopdetails == null) { return Ok("Empty"); }
    //        else
    //        {
    //            await _service.Delete(id);
    //            return RedirectToAction(nameof(Index));
    //        }

    //    }
    //}
}
