namespace BookShop
{
    using BookShop.Models;
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();

            //int input= int.Parse(Console.ReadLine());
            Console.WriteLine(RemoveBooks(db));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            string[] titles = context.Books
                                     .Where(x => x.AgeRestriction == Enum.Parse<AgeRestriction>(command, true))
                                     .Select(x => x.Title)
                                     .OrderBy(x => x)
                                     .ToArray();

            return String.Join(Environment.NewLine, titles);
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            string[] titles = context.Books
                                    .Where(x => x.EditionType == EditionType.Gold && x.Copies < 5000)
                                    .OrderBy(x => x.BookId)
                                    .Select(x => x.Title)
                                    .ToArray();


            return String.Join(Environment.NewLine, titles);
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                               .Where(x => x.Price > 40)
                               .OrderByDescending(x => x.Price)
                               .ToArray();


            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();



        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            string[] titles = context.Books
                                      .Where(x => x.ReleaseDate.Value.Year != year)
                                      .OrderBy(x => x.BookId)
                                      .Select(x => x.Title)
                                      .ToArray();


            return String.Join(Environment.NewLine, titles);
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            List<string> categories = input
                                      .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                      .Select(x => x.ToLower())
                                      .ToList();


            string[] titles = context.BooksCategories
                                     .Where(x => categories.Contains(x.Category.Name.ToLower()))
                                     .Select(x => x.Book.Title)
                                     .ToArray();
            return String.Join(Environment.NewLine, titles.OrderBy(x => x));
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            int[] dates = date.Split("-").Select(int.Parse).ToArray();

            DateTime dateLast = new DateTime(dates[2], dates[1], dates[0]);

            var books = context.Books
                                     .Where(x => x.ReleaseDate < dateLast)
                                     .OrderByDescending(x => x.ReleaseDate)
                                     .Select(x => new { x.Title, x.EditionType, x.Price })
                                     .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType.ToString()} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var names = context.Authors.Where(x => x.FirstName.EndsWith(input)).Select(x => new { FirstName = x.FirstName, LastName = x.LastName });

            StringBuilder sb = new StringBuilder();
            foreach (var item in names.OrderBy(x => x.FirstName).ThenBy(x => x.LastName))
            {
                sb.AppendLine($"{item.FirstName} {item.LastName}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var names = context.Books.Select(x => x.Title).Where(x => x.ToLower().Contains(input.ToLower())).OrderBy(x => x);



            StringBuilder sb = new StringBuilder();

            foreach (var title in names)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                               .Where(x => x.Author.LastName.ToLower().StartsWith(input.ToLower()))
                               .OrderBy(x => x.BookId)
                               .Select(
                                            x => new
                                            {
                                                Title = x.Title,
                                                AuthorFirstName = x.Author.FirstName,
                                                AuthorLastName = x.Author.LastName
                                            }
                                      );
            StringBuilder sb = new StringBuilder();
            foreach (var item in books)
            {
                sb.AppendLine($"{item.Title} ({item.AuthorFirstName} {item.AuthorLastName})");
            }
            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            return context.Books.Select(t => t.Title).Where(t => t.Length > lengthCheck).Count();
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var answer = context.Authors
                .Select(x => new
                {
                    AuthorName = x.FirstName + " " + x.LastName,
                    Copies = x.Books.Sum(y => y.Copies)
                });

            StringBuilder sb = new StringBuilder();
            foreach (var item in answer.OrderByDescending(x => x.Copies))
            {
                sb.AppendLine($"{item.AuthorName} - {item.Copies}");
            }

            return sb.ToString().Trim();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var answer = context.Categories.Select(x => new { Name = x.Name, Sum = x.CategoryBooks.Sum(x => x.Book.Copies * x.Book.Price) });


            StringBuilder sb = new StringBuilder();
            foreach (var item in answer.OrderByDescending(x => x.Sum))
            {
                sb.AppendLine($"{item.Name} ${item.Sum:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var answer = context.Categories.Select(x => new { Name = x.Name, Books = x.CategoryBooks.OrderByDescending(x => x.Book.ReleaseDate).Take(3).Select(x => new { Title = x.Book.Title, Year = x.Book.ReleaseDate.Value.Year }) }).OrderBy(x => x.Name);


            StringBuilder sb = new StringBuilder();
            foreach (var item in answer)
            {
                sb.AppendLine($"--{item.Name}");
                foreach (var book in item.Books)
                {
                    sb.AppendLine($"{book.Title} ({book.Year})");
                }

            }

            return sb.ToString().Trim();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            Book[] books = context.Books.Where(x => x.ReleaseDate.Value.Year < 2010).ToArray();
            foreach (var book in books)
            {
                book.Price += 5;
            }
            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context) 
        {
            Book[] books = context.Books.Where(x=>x.Copies<4200).ToArray();

            int count = 0;

            foreach (var book in books)
            {
                count++;
                context.Books.Remove(book);
            }
            context.SaveChanges();
            return count;
        }
    }
}
