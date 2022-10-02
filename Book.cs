using System;
using System.Collections.Generic;
using System.Text;

namespace usdpRev
{
	class Book
	{
        private static int nextId = 1;

        public static readonly string AVAILABLE = "Available";
        public static readonly string ON_LOAN = "On loan";

        public string Author { get; }
        public int Id { get; }
        public string ISBN { get; }
        public string Status { get; private set; }
        public string Title { get; }

        public Book(string author, string isbn, string title)
        {
            Id = nextId++;
            Author = author;
            ISBN = isbn;
            Title = title;
            Status = AVAILABLE;
        }

        public void SetAvailable()
        {
            Status = AVAILABLE;
        }

        public void SetOnLoan()
        {
            Status = ON_LOAN;
        }
    }
}
