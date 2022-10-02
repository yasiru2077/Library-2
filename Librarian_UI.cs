using System;
using System.Collections.Generic;
using System.Text;

namespace usdpRev
{
	class Librarian_UI
	{
        private BookManager bookMgr;
        private LoanManager loanMgr;

        public Librarian_UI(BookManager bookMgr, LoanManager loanMgr)
        {
            this.bookMgr = bookMgr;
            this.loanMgr = loanMgr;
        }

        public List<Book> ViewAllBooks()
        {
            return bookMgr.GetAllBooks();
        }

        public List<Loan> ViewCurrentLoans()
        {
            return loanMgr.GetCurrentLoans();
        }
    }
}
