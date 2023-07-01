using Library.Contracts;
using Library.Models.Book;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using System.Security.Claims;

namespace Library.Controllers
{
    [Authorize]
    public class BookController : Controller
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            //get the books from the service and pass them to the view
            var booksModel = await bookService.GetAllBooksAsync();

            return View(booksModel);
        }


        public async Task<IActionResult> Mine()
        {
            //get the books from the service and pass them in the view
            var myBooks = await bookService.GetMyBooks(GetUserId());

            return View(myBooks);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //get the categories and create empty AddBookViewModel with only Categories prop filled and pass it to the View
            var bookModel = new AddBookViewModel()
            {
                Categories = await bookService.GetCategories()
            };

            return View(bookModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel model)
        {
            //pass the model to the service if the model is valid and add it to the tables
            decimal rating;

            if (!decimal.TryParse(model.Rating, out rating) || rating < 0 || rating > 10)
            {
                ModelState.AddModelError(nameof(model.Rating), "Rating must be a number between 0 and 10.");

                return View(model);
            }

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            await bookService.AddBookAsync(model);


            return RedirectToAction("All", "Book");
        }

        
        public async Task<IActionResult> AddToCollection(int id)
        {
            //get the user id
            throw new Exception();
            string userId = GetUserId();

            //pass that information to create the IdentityUserBooks in the service

            await bookService.AddToCollection(id,userId);
            return RedirectToAction("All" , "Book");
        }

        public async Task<IActionResult> RemoveFromCollection(int id) 
        {
            //get the user id 
            string userId = GetUserId();
            //pass it to the service where we find the row and delete it
            await bookService.RemoveFromCollection(id,userId);

            return RedirectToAction("Mine", "Book");
        }


        public string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

    }
}
