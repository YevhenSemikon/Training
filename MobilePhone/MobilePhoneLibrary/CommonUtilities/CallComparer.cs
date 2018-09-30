using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.CommonUtilities
{
    class CallComparer : IComparer <List<Call>>, IComparer<Call>
    {
        public int Compare(List<Call> x, List<Call> y)
        {
             
            if (x.Max(c => c.ReceivingCallTime) == y.Max(c => c.ReceivingCallTime))
            {
                return 0;
            }
            if (x.Max(c=>c.ReceivingCallTime) >= y.Max(c => c.ReceivingCallTime))
            {
                return -1;
            }

            return 1;
        }
        public int Compare(Call x, Call y)
        {

            if (x.ReceivingCallTime == y.ReceivingCallTime)
            {
                return 0;
            }
            if (x.ReceivingCallTime >= y.ReceivingCallTime)
            {
                return -1;
            }

            return 1;
        }

    }
}
