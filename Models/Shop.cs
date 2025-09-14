using System.ComponentModel.DataAnnotations;

namespace Bookstore_Ecommerce.Models
{
    public class Shop
    {
        [Key] 
        public int Id { get; set; }
        [Display(Name="Shop logo")]
        public string Shoplogo { get; set; }
        [Display(Name = "Shop Name")]
        public string Name { get; set; }
        [Display(Name = "Shop Location")]
        public string Location { get; set; }

        //relation 
        public List<Book_Shop> Book_shop { get; set; }
    }
}
