using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private List<Book> Books;
        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(Books);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public Library(params Book[] books)
        {
            Books = new List<Book>(books);
            Books.Sort( new BookComparator());
        }
        private class LibraryIterator : IEnumerator<Book>
        {
            private readonly List<Book> books;

            private int currentIndex = -1;
            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                books.Sort(new BookComparator());
            }

            public Book Current => books[currentIndex];

            object IEnumerator.Current => Current;

            public void Dispose() { }

            public bool MoveNext()
            {
                return ++currentIndex < books.Count;
            }

            public void Reset() { }
        }
    }
}
