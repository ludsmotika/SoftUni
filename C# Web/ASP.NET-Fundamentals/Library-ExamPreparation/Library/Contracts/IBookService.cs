
using Library.Models.Book;
using Library.Models.Category;

namespace Library.Contracts
{
    public interface IBookService
    {

        Task<IEnumerable<AllBooksViewModel>> GetAllBooksAsync();

        Task<IEnumerable<MyBookViewModel>> GetMyBooks(string id);

        Task<IEnumerable<CategoryViewModel>> GetCategories();

        Task AddBookAsync(AddBookViewModel model);

        Task AddToCollection(int bookId, string userId); 

        Task RemoveFromCollection(int bookId,string userId);

    }
}
