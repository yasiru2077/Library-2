using System;
using System.Collections.Generic;
using System.Text;

namespace usdpRev
{
	class BookManager
	{
        private SortedDictionary<int, Book> books = new SortedDictionary<int, Book>();

        public void AddBook(Book b)
        {
            books.Add(b.Id, b);
        }

        public Book FindBook(int bookId)
        {
            try
            {
                return books[bookId];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception($"Book {bookId} does not exist");
            }
        }

        public List<Book> GetAllBooks()
        {
            List<Book> list = new List<Book>(books.Count);

            foreach (Book b in books.Values)
            {
                list.Add(b);
            }

            return list;
        }
    }
}
