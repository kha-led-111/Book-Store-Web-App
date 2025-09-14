using Bookstore_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bookstore_Ecommerce.Data.Base
{
    public class EntityBaseRep<T> : IEntityBaseRep<T> where T : class, IEntityBase, new()
    {
        private readonly BookEcContext _context;
        public EntityBaseRep(BookEcContext context)
        {
            _context = context;
        }
        public async Task Add(T entity)
        {
            _context.Set<T>().Add(entity);
           await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity= await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id); 
            EntityEntry entityentry = _context.Entry<T>(entity);
            entityentry.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IEnumerable<T> Getall()
        {
            var entities = _context.Set<T>().ToList();
            return entities;
            
        }

        public async Task<T> GetbyId(int id)
        {
            var entity=await _context.Set<T>().FirstOrDefaultAsync( n=>n.Id==id);
            return entity;
            
        }

        public async Task UpdateAsync(int id, T entity)
        {

            var existingEntity = await _context.Set<T>().FindAsync(id);
            if (existingEntity == null)
                throw new Exception("Entity not found");

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);
            await _context.SaveChangesAsync();



        }
    }
}
