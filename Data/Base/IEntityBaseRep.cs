using Bookstore_Ecommerce.Models;

namespace Bookstore_Ecommerce.Data.Base
{
    public interface IEntityBaseRep<T> where T : class,IEntityBase, new()
    {
        IEnumerable<T> Getall();
        Task<T> GetbyId(int id);
         Task Add(T entity);
        Task UpdateAsync(int id, T entity);
        Task Delete(int id);

    }
}
