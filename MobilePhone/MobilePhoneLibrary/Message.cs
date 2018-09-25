using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone {
    public class Message {
        public Message(string user, string text, DateTime receivingTime) {
            User = user;
            Text = text;
            ReceivingTime = receivingTime;
        }
        public string User { get; set; }
        public string Text { get; set; }
        public DateTime ReceivingTime { get; set; }
    }

}
