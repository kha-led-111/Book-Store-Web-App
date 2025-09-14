using Bookstore_Ecommerce.Data.Base;
using Bookstore_Ecommerce.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Bookstore_Ecommerce.Data.Service
{
    public class BookService : EntityBaseRep<Book>, IBookService
    {
        public BookService(BookEcContext context) :base(context){ }

        object IBookService.Include(Func<object, object> value)
        {
            throw new NotImplementedException();
        }
    }
}
