using Bookstore_Ecommerce.Data.Base;
using Bookstore_Ecommerce.Models;

namespace Bookstore_Ecommerce.Data.Service
{
    public interface IBookService : IEntityBaseRep<Book>
    {
        object Include(Func<object, object> value);
    }
}
