using System.ComponentModel.DataAnnotations;
using Bookstore_Ecommerce.Data.Base;

namespace Bookstore_Ecommerce.Models
{
    public class Author:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "profile picture")]
        public string Profile_picture { get; set; }//image

        [Required]
        [Display(Name = "full name")]
        public string fullname { get; set; }
        [Display(Name = "Bio")]
        public string  Bio { get; set; }

        //relations
        public List<Book> Books { get; set; }
    }
}
