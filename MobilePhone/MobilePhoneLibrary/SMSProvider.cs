using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone {
    internal class SMSProvider {
        private int sequenceMessageNumber = 0;

        public SMSProvider(int messageNumber, int pause, Storage storage) { CreateMessages(messageNumber, pause, storage); }

        public void CreateMessages(int messagesNumber, int pause, Storage storage) {
            for (int i = 0; i < messagesNumber; i++) {
                storage.AddMessage(new Message("+380971234567", $"Message #{sequenceMessageNumber++} received!", DateTime.Now));
                System.Threading.Thread.Sleep(pause);
                storage.AddMessage(new Message("+380971234568", $"Message #{sequenceMessageNumber++} received!", DateTime.Now));
                System.Threading.Thread.Sleep(pause);
                storage.AddMessage(new Message("+380971234569", $"Message #{sequenceMessageNumber++} received!", DateTime.Now));
                System.Threading.Thread.Sleep(pause);
            }
        }
    }
}
