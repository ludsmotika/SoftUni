using Library.Contracts;
using Library.Data;
using Library.Data.Models;
using Library.Models.Book;
using Library.Models.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Versioning;
using System.Security.Cryptography.Xml;

namespace Library.Services
{
    public class BookService : IBookService
    {

        private readonly LibraryDbContext context;
        public BookService(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task AddBookAsync(AddBookViewModel model)
        {
            //create real book model and it to the db

            Book bookToAdd = new Book()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                Rating = decimal.Parse(model.Rating),
                CategoryId = model.CategoryId,
                ImageUrl = model.Url
            };

            await context.Books.AddAsync(bookToAdd);
            await context.SaveChangesAsync();

        }

        public async Task AddToCollection(int bookId, string userId)
        {
            //create IdentityUser and adds it to the context and save changes

            bool alreadyAdded = await context.IdentityusersBooks
                .AnyAsync(ub => ub.CollectorId == userId && ub.BookId == bookId);

            if (alreadyAdded == false)
            {
                IdentityUserBook userBook = new IdentityUserBook()
                {
                    BookId = bookId,
                    CollectorId = userId
                };

                await context.IdentityusersBooks.AddAsync(userBook);
                await context.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<AllBooksViewModel>> GetAllBooksAsync()
        {
            //get the books
            var booksModel = await context.Books.Select(x => new AllBooksViewModel()
            {
                Id = x.Id,
                Title = x.Title,
                Rating = x.Rating,
                Author = x.Author,
                Category = x.Category.Name,
                ImageUrl = x.ImageUrl
            }).ToListAsync();

            return booksModel;
        }

        public async Task<IEnumerable<CategoryViewModel>> GetCategories()
        {
            var categories = await context.Categories.Select(x => new CategoryViewModel()
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();

            return categories;
        }

        public async Task<IEnumerable<MyBookViewModel>> GetMyBooks(string id)
        {
            //get my books from the many to many table 
            var myBooks = await context.IdentityusersBooks
                                 .Where(x => x.CollectorId == id)
                                 .Select(x => new MyBookViewModel()
                                 {
                                     Id = x.BookId,
                                     Title = x.Book.Title,
                                     Author = x.Book.Author,
                                     ImageUrl = x.Book.ImageUrl,
                                     Description = x.Book.Description,
                                     Category = x.Book.Category.Name
                                 }).ToListAsync();

            return myBooks;
        }

        public async Task RemoveFromCollection(int bookId, string userId)
        {
            IdentityUserBook userBook = context.IdentityusersBooks.First(x => x.CollectorId == userId && x.BookId == bookId);

            if (userBook != null)
            {
                context.IdentityusersBooks.Remove(userBook);
                await context.SaveChangesAsync();
            }
        }
    }
}
