using System;
using System.Collections.Generic;

namespace usdpRev
{
	class Program
	{
        private const int BORROW_BOOK = 1;
        private const int RETURN_BOOK = 2;
        private const int RENEW_LOAN = 3;
        private const int VIEW_ALL_BOOKS = 4;
        private const int VIEW_CURRENT_LOANS = 5;
        private const int EXIT = 6;

        private static Librarian_UI libUI;
        private static Member_UI memUI;

        static void Main(string[] args)
        {
            InitialiseData();

            DisplayMenu();
            int choice = GetMenuChoice();

            while (choice != EXIT)
            {
                switch (choice)
                {
                    case BORROW_BOOK:
                        BorrowBook();
                        break;
                    case RETURN_BOOK:
                        ReturnBook();
                        break;
                    case RENEW_LOAN:
                        RenewLoan();
                        break;
                    case VIEW_ALL_BOOKS:
                        ViewAllBooks();
                        break;
                    case VIEW_CURRENT_LOANS:
                        ViewCurrentLoans();
                        break;
                }
                DisplayMenu();
                choice = GetMenuChoice();
            }
        }

        private static void InitialiseData()
        {
            BookManager bookMgr = new BookManager();
            LoanManager loanMgr = new LoanManager();
            MemberManager memberMgr = new MemberManager(bookMgr, loanMgr);

            libUI = new Librarian_UI(bookMgr, loanMgr);
            memUI = new Member_UI(loanMgr, memberMgr);

            memberMgr.AddMember(new Member("Graham"));
            memberMgr.AddMember(new Member("Phil"));
            memberMgr.AddMember(new Member("Adam"));

            bookMgr.AddBook(new Book("Author 1", "Title 1", "1234567890"));
            bookMgr.AddBook(new Book("Author 2", "Title 2", "2345678901"));
            bookMgr.AddBook(new Book("Author 3", "Title 3", "3456789012"));
            bookMgr.AddBook(new Book("Author 4", "Title 4", "4567890123"));
        }

        private static void DisplayMenu()
        {
            Console.WriteLine($"\n{BORROW_BOOK} Borrow book");
            Console.WriteLine($"{RETURN_BOOK} Return book");
            Console.WriteLine($"{RENEW_LOAN} Renew loan");
            Console.WriteLine($"{VIEW_ALL_BOOKS} View all books");
            Console.WriteLine($"{VIEW_CURRENT_LOANS} View current loans");
            Console.WriteLine($"{EXIT} Exit");
        }

        private static int GetMenuChoice()
        {
            int option = ReadInteger("\nOption");
            while (option < 1 || option > 6)
            {
                Console.WriteLine("\nChoice not recognised. Please try again");
                option = ReadInteger("\nOption");
            }
            return option;
        }

        private static int ReadInteger(string prompt)
        {
            try
            {
                Console.Write(prompt + ": > ");
                return Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception)
            {
                return -1;
            }
        }

        private static void BorrowBook()
        {
            int memberId = ReadInteger("\nMember ID");
            int bookId = ReadInteger("Book ID");
            try
            {
                memUI.BorrowBook(memberId, bookId);
                Console.WriteLine("\nBook borrowed");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }

        private static void ReturnBook()
        {
            int memberId = ReadInteger("\nMember ID");
            int bookId = ReadInteger("Book ID");
            try
            {
                memUI.ReturnBook(memberId, bookId);
                Console.WriteLine("\nBook returned");
            }
            catch (Exception e)
            {
                Console.WriteLine("\n" + e.Message);
            }
        }

        private static void RenewLoan()
        {
            int memberId = ReadInteger("\nMember ID");
            int bookId = ReadInteger("Book ID");
            Console.WriteLine("\nLoan has {0}been renewed",memUI.RenewLoan(memberId, bookId) ? "" : "not ");
        }

        private static void ViewAllBooks()
        {
            List<Book> books = libUI.ViewAllBooks();
            Console.WriteLine("\nAll books");
            Console.WriteLine("\t{0, -4} {1, -20} {2, -20} {3, -10}    {4}", "ID", "Title", "Author", "ISBN", "Status");
            foreach (Book b in books)
            {
                DisplayBook(b);
            }
        }

        private static void DisplayBook(Book b)
        {
            Console.WriteLine(
                "\t{0, -4} {1, -20} {2, -20} {3, -10}    {4}",
                b.Id,
                b.Title,
                b.Author,
                b.ISBN,
                b.Status);
        }

        private static void ViewCurrentLoans()
        {
            List<Loan> loans = libUI.ViewCurrentLoans();
            Console.WriteLine("\nCurrent loans");
            Console.WriteLine("\t{0, -20} {1, -20} {2, -12} {3, -12} {4, -8}", "Title", "Borrower", "Loan date", "Due date", "Renewals");
            foreach (Loan loan in loans)
            {
                DisplayLoan(loan);
            }
        }

        private static void DisplayLoan(Loan loan)
        {
            Console.WriteLine(
                "\t{0, -20} {1, -20} {2, -12} {3, -12}    {4}",
                loan.Book.Title,
                loan.Member.Name,
                loan.LoanDate.ToString("dd/MM/yyyy"),
                loan.DueDate.ToString("dd/MM/yyyy"),
                loan.NumberOfRenewals);
        }
    }
}
