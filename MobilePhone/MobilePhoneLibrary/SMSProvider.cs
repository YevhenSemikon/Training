using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone {
    internal class SMSProvider {
        private int sequenceMessageNumber=0;

        public SMSProvider(Storage storage) {  CreateMessages(100,storage); }
    
        public void CreateMessages(int messagesNumber,Storage storage) {
            for (int i = 0; i < messagesNumber; i++) {
                storage.AddMessage(new Message("+380971234567", $"Message #{sequenceMessageNumber++} received!", DateTime.Now));
                System.Threading.Thread.Sleep(1000);
                storage.AddMessage(new Message("+380971234568", $"Message #{sequenceMessageNumber++} received!", DateTime.Now));
                System.Threading.Thread.Sleep(1000);
                storage.AddMessage(new Message("+380971234569", $"Message #{sequenceMessageNumber++} received!", DateTime.Now));
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
