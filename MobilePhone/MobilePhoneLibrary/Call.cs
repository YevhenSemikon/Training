using MobilePhone.CommonUtilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone
{
    public class Call
    {
        public Call()
        {
            Direction = Direction.Incoming;
            ReceivingCallTime = DateTime.Now;
            CallContact = new Contact();
        }
        public Call(Direction direction, DateTime receivingCallTime, Contact contact)
        {
            Direction = direction;
            ReceivingCallTime = receivingCallTime;
            CallContact = contact;
        }

        public Direction Direction { get; set; }
        public DateTime ReceivingCallTime { get; set; }
        public Contact CallContact { get; set; }

    }
}

