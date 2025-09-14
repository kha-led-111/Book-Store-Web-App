using System.ComponentModel.DataAnnotations;
using Bookstore_Ecommerce.Data.Base;

namespace Bookstore_Ecommerce.Models
{
    public class Publishing_House :IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="logo")]
        public string Logo { get; set; }
        [Display(Name = "full name")]
        public string Fullname { get; set; }
        [Display(Name = "Biography ")]
        public string Bio { get; set; }
        //relation 
        public List<Book> books { get; set; }
    }
}
