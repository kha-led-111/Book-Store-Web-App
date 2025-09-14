using Bookstore_Ecommerce.Data.Base;
using Bookstore_Ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookstore_Ecommerce.Data.Service
{
    public class AuthorService : EntityBaseRep<Author>, IAuthorService
    {
        

        public AuthorService(BookEcContext context) : base(context) { 
           
        }
       

    }
}
