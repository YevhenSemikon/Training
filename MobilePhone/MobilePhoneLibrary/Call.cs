using MobilePhone.CommonUtilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone {
    public class Call {
        public Call() {
            Direction = Direction.Incoming;
            ReceivingCallTime = DateTime.Now;
            CallContact = new Contact();
        }
        public Call(Direction direction, DateTime receivingCallTime, Contact contact) {
            Direction = direction;
            ReceivingCallTime = receivingCallTime;
            CallContact = contact;
        }

        public Direction Direction { get; set; }
        public DateTime ReceivingCallTime { get; set; }
        public Contact CallContact { get; set; }


        public override bool Equals(object obj) {

            if (obj == null) {
                return false;
            }
            Call c = obj as Call;
            if (c == null) {
                return false;
            }

            if (Direction != c.Direction) { return false; }
            if (CallContact.ContactPhoneNumber != c.CallContact.ContactPhoneNumber) { return false; }
            return true;
        }
        public override int GetHashCode() {
            return base.GetHashCode();
        }
    }
}


