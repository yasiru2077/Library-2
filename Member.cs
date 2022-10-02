using System;
using System.Collections.Generic;
using System.Text;

namespace usdpRev
{
	class Member
	{
        private static int nextId = 1;

        public int Id { get; }
        public string Name { get; }
        public int NumberOfLoans { get; private set; }

        public Member(string name)
        {
            this.Id = nextId++;
            this.Name = name;
            this.NumberOfLoans = 0;
        }

        public bool DecrementNumberOfLoans()
        {
            if (NumberOfLoans > 0)
            {
                NumberOfLoans--;
                return true;
            }

            return false;
        }

        public bool IncrementNumberOfLoans()
        {
            if (NumberOfLoans < 6)
            {
                NumberOfLoans++;
                return true;
            }

            return false;
        }
    }
}
