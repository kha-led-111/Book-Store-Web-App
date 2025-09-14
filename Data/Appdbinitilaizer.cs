using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Bookstore_Ecommerce.Models;
namespace Bookstore_Ecommerce.Data
{
    public class Appdbinitilaizer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicescope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicescope.ServiceProvider.GetService<BookEcContext>();


                 context.Database.EnsureCreated();

                //publish house
                if (!context.publish_house.Any())
                {
                    context.publish_house.AddRange(new List<Publishing_House>
                    {
                        new Publishing_House()
                        {
                            Logo="https://static.vecteezy.com/system/resources/thumbnails/059/231/500/small/sunlight-streams-onto-a-vintage-typewriter-surrounded-by-books-and-oldgraphs-photo.jpg",
                            Bio="the oldest publish house",
                            Fullname="Alnour",
                        },
                         new Publishing_House()
                        {
                            Logo="https://static.vecteezy.com/system/resources/thumbnails/059/231/500/small/sunlight-streams-onto-a-vintage-typewriter-surrounded-by-books-and-oldgraphs-photo.jpg",
                            Bio="the oldest publish house",
                            Fullname="Alnour2",
                        },
                          new Publishing_House()
                        {
                            Logo="https://static.vecteezy.com/system/resources/thumbnails/059/231/500/small/sunlight-streams-onto-a-vintage-typewriter-surrounded-by-books-and-oldgraphs-photo.jpg",
                            Bio="the oldest publish house",
                            Fullname="Alnour3",
                        },
                           new Publishing_House()
                        {
                            Logo="https://static.vecteezy.com/system/resources/thumbnails/059/231/500/small/sunlight-streams-onto-a-vintage-typewriter-surrounded-by-books-and-oldgraphs-photo.jpg",
                            Bio="the oldest publish house",
                            Fullname="Alnour4",
                        },
                    });
                    context.SaveChanges();
                }



                //author
                if (!context.author.Any())
                {
                    context.author.AddRange(new List<Author> {
                     new Author()
                     {
                         Profile_picture="https://media.istockphoto.com/id/1478316046/photo/portrait-of-high-school-teacher-at-school-library.jpg?s=612x612&w=0&k=20&c=sSU4PQgVZXW6jiddn8YcB3s2F_Vge5RekkWBlMiUKuU=",
                         fullname="author 1",
                         Bio="the first author",
                     },
                       new Author()
                     {
                         Profile_picture="https://images.squarespace-cdn.com/content/v1/64bfd6aa127fba0754a78d65/1690617601186-7MS4W32UWBXKFKZTCQ14/authorphotos5-1024x683.jpg",
                         fullname="author 1",
                         Bio="the first author",
                     },
                         new Author()
                     {
                         Profile_picture="https://images.squarespace-cdn.com/content/v1/64bfd6aa127fba0754a78d65/1690617601186-7MS4W32UWBXKFKZTCQ14/authorphotos5-1024x683.jpg",
                         fullname="author 1",
                         Bio="the first author",
                     },
                    });
                    context.SaveChanges();
                };
               

                //book
                if (!context.books.Any())
                {
                    context.books.AddRange(new List<Book>()
                    {
                        new Book()
                        {
                            Book_Name="book1",
                            Description="the first book",
                            Publish_data=new DateOnly(2005,10,5),
                            price=20,
                            Category=Category.crime,
                            AuthorId=1,
                            Publish_houseId=1,
                            Image="https://abseil.io/img/swe_at_google.2.cover.jpg"
                        },
                        new Book()
                        {
                             Book_Name="book2",
                            Description="the 2th book",
                            Publish_data=new DateOnly(2005,10,5),
                            price=20,
                            Category=Category.history,
                            AuthorId=2,
                            Publish_houseId=2,
                            Image="https://m.media-amazon.com/images/I/81sji+WquSL._UF1000,1000_QL80_.jpg"

                        },
                        new Book()
                        {
                               Book_Name="book3",
                            Description="the first book",
                            Publish_data=new DateOnly(2005,10,5),
                            price=20,
                            Category=Category.crime,
                            AuthorId=1,
                            Publish_houseId=1,
                            Image="https://www.vandanapublications.com/_app_data/PRODUCT/20231207174457-software-engineering-question-and-answer-book.jpg"

                        },
                        new Book()
                        {
                                 Book_Name="book4",
                            Description="the first book",
                            Publish_data=new DateOnly(2005,10,5),
                            price=20,
                            Category=Category.crime,
                            AuthorId=1,
                            Publish_houseId=2,
                            Image="https://geniuspublicationsjaipur.wordpress.com/wp-content/uploads/2013/04/software-engineering-book.jpg"

                        },
                         new Book()
                        {
                                 Book_Name="book5",
                            Description="the first book",
                            Publish_data=new DateOnly(2005,10,5),
                            price=20,
                            Category=Category.crime,
                            AuthorId=1,
                            Publish_houseId=1,
                            Image="https://geniuspublicationsjaipur.wordpress.com/wp-content/uploads/2013/04/software-engineering-book.jpg"

                        },
                          new Book()
                        {
                                 Book_Name="book6",
                            Description="the first book",
                            Publish_data=new DateOnly(2005,10,5),
                            price=20,
                            Category=Category.crime,
                            AuthorId=1,
                            Publish_houseId=3
                            ,
                            Image="https://geniuspublicationsjaipur.wordpress.com/wp-content/uploads/2013/04/software-engineering-book.jpg"

                        },
                    });
                    context.SaveChanges();

                };
                
               
                
                //shop
                if (!context.shops.Any())
                {
                    context.shops.AddRange(new List<Shop> {
                     new Shop() { 
                      Shoplogo="https://img.freepik.com/free-vector/flat-design-library-logo-design_23-2149324478.jpg",
                      Location="22 paker st",
                      Name="library1",
                     },
                     new Shop() {
                      Shoplogo="https://img.freepik.com/free-vector/flat-design-library-logo-design_23-2149324478.jpg",
                      Location="22 paker st",
                      Name="library2",
                     },
                     new Shop() {
                      Shoplogo="https://img.freepik.com/free-vector/flat-design-library-logo-design_23-2149324478.jpg",
                      Location="22 paker st",
                      Name="library3",
                     },
                     new Shop() {
                      Shoplogo="https://img.freepik.com/free-vector/flat-design-library-logo-design_23-2149324478.jpg",
                      Location="22 paker st",
                      Name="library4",
                     },

                    });
                    context.SaveChanges ();

                };
                //book shop
                if (!context.book_shop.Any())
                {
                    context.book_shop.AddRange(new List<Book_Shop> { 
                     new Book_Shop() {
                         Bookid=1,
                         Shopid=1,
                     },
                     new Book_Shop() {
                         Bookid=1,
                         Shopid=2,
                     },
                     new Book_Shop() {
                         Bookid=1,
                         Shopid=3,
                     },
                     new Book_Shop() {
                         Bookid=2,
                         Shopid=1,
                     },
                     new Book_Shop() {
                         Bookid=2,
                         Shopid=3,
                     },
                     new Book_Shop() {
                         Bookid=3,
                         Shopid=2,
                     },
                     new Book_Shop() {
                         Bookid=3,
                         Shopid=4,
                     },
                     new Book_Shop() {
                         Bookid=4,
                         Shopid=1,
                     },
                     new Book_Shop() {
                         Bookid=5,
                         Shopid=1,
                     },
                     new Book_Shop() {
                         Bookid=6,
                         Shopid=4,
                     },
                    });
                    context.SaveChanges();

                };





            }
            ;

        }

        

    }
}
