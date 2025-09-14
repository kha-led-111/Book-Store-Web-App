using Bookstore_Ecommerce.Models;
namespace Bookstore_Ecommerce.Data.Service
{
    public interface IShopService
    {
        IEnumerable<Shop> Getall();
        Task<Shop> GetbyId(int id);
        Task Add(Shop newshop);
        Task<Shop> UpdateAsync(int id,Shop newshop);
        Task Delete(int id);




    }
}
