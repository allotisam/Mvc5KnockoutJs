using BootstrapIntro.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BootstrapIntro.DAL
{
    public class BookInitializer : DropCreateDatabaseIfModelChanges<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            base.Seed(context);

            var author = new List<Author>
            {
                new Author { FirstName = "Jamie", LastName = "Munro", Biography = "..." },
                new Author { FirstName = "William",LastName = "Shakespeare",Biography = "1564 - 1616"},
                new Author { FirstName = "Ernest",LastName = "Hemingway",Biography = "1899 - 1961"},
                new Author { FirstName = "George R.R.",LastName = "Martin",Biography = "..."},
                new Author { FirstName = "Charles", LastName="Dickens", Biography="1812 - 1870"} ,
                new Author { FirstName="Stephen", LastName="King", Biography="..." },
                new Author { FirstName="Jane", LastName="Austen", Biography="..." },
                new Author { FirstName="Mark", LastName="Twain", Biography="..."},
                new Author { FirstName="J.K.", LastName="Rowling", Biography="Born 1965" },
                new Author { FirstName="George", LastName="Orwell", Biography="Eric Arthur Blair, better known by the pen name George Orwell, was an English novelist, essayist, journalist, and critic. His work is marked by lucid prose, awareness of social injustice, opposition to totalitarianism, and outspoken support of democratic socialism." },
                new Author { FirstName="Veronica", LastName="Roth", Biography="..." },
                new Author { FirstName="Suki", LastName="Kim", Biography="Suki Kim is the author of the award-winning novel The Interpreter and the recipient of Guggenheim, Fulbright, and Open Society fellowships. She has been traveling to North Korea as a journalist since 2002, and her essays and articles have appeared in the New York Times, Harper’s, and the New York Review of Books. Born and raised in Seoul, she lives in New York." }
            };
            author.ForEach(a => context.Authors.Add(a));
            context.SaveChanges();

            var books = new List<Book>
            {
                new Book {
                    Author = author[0],
                    Description = "...",
                    ImageUrl = "http://ecx.images-amazon.com/images/I/51T%2BWt430bL._AA160_.jpg",
                    Isbn = "1491914319",
                    Synopsis = "...",
                    Title = "Knockout.js: Building Dynamic Client-Side Web Applications"
                },
                    new Book {
                    Author = author[0],
                    Description = "...",
                    ImageUrl = "http://ecx.images-amazon.com/images/I/51AkFkNeUxL._AA160_.jpg",
                    Isbn = "1449319548",
                    Synopsis = "...",
                    Title = "20 Recipes for Programming PhoneGap: Cross-Platform Mobile Development"
                },
                new Book {
                    Author = author[0],
                    Description = "...",
                    ImageUrl = "http://ecx.images-amazon.com/images/I/51LpqnDq8-L._AA160_.jpg",
                    Isbn = "1449309860",
                    Synopsis = "...",
                    Title = "20 Recipes for Programming MVC 3: Faster, Smarter Web Development"
                },
                new Book {
                    Author = author[0],
                    Description = "...",
                    ImageUrl = "http://ecx.images-amazon.com/images/I/41JC54HEroL._AA160_.jpg",
                    Isbn = "1460954394",
                    Synopsis = "...",
                    Title = "Rapid Application Development With CakePHP"
                }
            };

            books.ForEach(b => context.Books.Add(b));
            context.SaveChanges();
        }
    }
}