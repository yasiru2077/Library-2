using System;
using System.Collections.Generic;
using System.Text;

namespace usdpRev
{
	class Loan
	{
        private static int nextId = 1;

        public int Id { get; }
        public Member Member { get; }
        public Book Book { get; }
        public DateTime DueDate { get; private set; }
        public DateTime LoanDate { get; }

        private DateTime returnDate;
        public DateTime ReturnDate
        {
            get
            {
                return returnDate;
            }

            set
            {
                returnDate = value;
                Book.SetAvailable();
                Member.DecrementNumberOfLoans();
            }
        }
        public int NumberOfRenewals { get; private set; }

        public Loan(Member m, Book b, DateTime loanDate)
        {
            Id = nextId++;
            Member = m;
            Book = b;
            Book.SetOnLoan();
            Member.IncrementNumberOfLoans();
            LoanDate = loanDate;
            DueDate = LoanDate.AddDays(14);
            NumberOfRenewals = 0;
        }

        public bool Renew()
        {
            if (NumberOfRenewals < 3)
            {
                DueDate = DueDate.AddDays(14);
                NumberOfRenewals++;
                return true;
            }

            return false;
        }
    }
}
