using System;
using System.Collections.Generic;
using System.Text;

namespace usdpRev
{
	class MemberManager
	{
        private BookManager bookMgr;
        private LoanManager loanMgr;

        private Dictionary<int, Member> members = new Dictionary<int, Member>();

        public MemberManager(BookManager bookMgr, LoanManager loanMgr)
        {
            this.bookMgr = bookMgr;
            this.loanMgr = loanMgr;
        }

        public void AddMember(Member m)
        {
            members.Add(m.Id, m);
        }

        public void BorrowBook(int memberId, int bookId)
        {
            Member m = FindMember(memberId);

            if (m != null && m.NumberOfLoans < 6)
            {
                Book b = bookMgr.FindBook(bookId);
                if (b != null && b.Status == Book.AVAILABLE)
                {
                    loanMgr.CreateLoan(m, b, DateTime.Now);
                }
            }
        }

        public Member FindMember(int memberId)
        {
            try
            {
                return members[memberId];
            }
            catch (KeyNotFoundException)
            {
                throw new Exception($"Member {memberId} does not exist");
            }
        }
    }
}
