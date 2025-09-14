using Bookstore_Ecommerce.Data.Base;
using Bookstore_Ecommerce.Models;

namespace Bookstore_Ecommerce.Data.Service
{
    public class Publishing_HouseService:EntityBaseRep<Publishing_House>,Ipublishing_HouseService
    {
        public Publishing_HouseService(BookEcContext context) : base(context) { }
        
    }
}
