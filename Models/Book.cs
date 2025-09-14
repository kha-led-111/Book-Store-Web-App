using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Bookstore_Ecommerce.Data;
using Bookstore_Ecommerce.Data.Base;

namespace Bookstore_Ecommerce.Models
{
    public class Book:IEntityBase
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "name")]
        [Required]
        public string Book_Name { get; set; }
        [Display(Name = "description")]
        public string Description { get; set; }
        [Display(Name = "book image")]
        public string Image { get; set; }

        [Display(Name = "publish date")]
        public DateOnly Publish_data { get; set; }
        [Display(Name = "price")]
        public int price { get; set; }

        //category is a enum  contain categores in file'data'
        public Category Category { get; set; }

        //relational data
        //we should define relation first
        
        //[ForeignKey("AuthorId")]
        public int AuthorId { get; set; }
        [JsonIgnore]
        public Author ?Author { get; set; }
        
       // [ForeignKey(nameof(Publish_house))]
        public int? Publish_houseId { get; set; }
        [JsonIgnore]
        public  Publishing_House? Publish_house { get; set; }
        [JsonIgnore]
        public List<Book_Shop>? Book_shop { get; set; }

    }
}
