using System;
using System.Collections.Generic;
using System.Text;

namespace usdpRev
{
	class Member_UI
	{
        private LoanManager loanMgr;
        private MemberManager memberMgr;

        public Member_UI(LoanManager loanMgr, MemberManager memberMgr)
        {
            this.loanMgr = loanMgr;
            this.memberMgr = memberMgr;
        }

        public void BorrowBook(int memberId, int bookId)
        {
            memberMgr.BorrowBook(memberId, bookId);
        }

        public void ReturnBook(int memberId, int bookId)
        {
            loanMgr.EndLoan(memberId, bookId);
        }

        public bool RenewLoan(int memberId, int bookId)
        {
            return loanMgr.RenewLoan(memberId, bookId);
        }
    }
}
