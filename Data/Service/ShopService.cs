using System.Threading.Tasks;
using Bookstore_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Ecommerce.Data.Service
{
    public class ShopService : IShopService
    {
        private readonly BookEcContext _context;
        public ShopService(BookEcContext context)
        {
            _context = context;
        }
        public async Task Add(Shop newshop)
        {
           _context.shops. Add(newshop);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            var result=await _context.shops.FirstOrDefaultAsync(n => n.Id == id);
             _context.shops.Remove(result);
            await _context.SaveChangesAsync();
            
            
        }

        public IEnumerable<Shop> Getall()
        {
            var resultGetAll=_context.shops.ToList();
            return resultGetAll;    
        }

        public async Task<Shop> GetbyId(int Id)
        {
           var result=await _context.shops.FirstOrDefaultAsync(n =>n.Id==Id);
            return result;
        }

        public async Task<Shop> UpdateAsync(int id, Shop newshop)
        {
           _context.Update(newshop);
            await _context.SaveChangesAsync();
            return newshop;
        }
    }
}
