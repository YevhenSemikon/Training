using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MobilePhone;

namespace MessageFormattingApp {
    public delegate void AddSMSProviderDelegate(int messageNumber, int pause, Storage storage);
    internal class SMSProvider {
        public SMSProvider() {
            ProviderName = "KievProvider";
        }
        public string ProviderName { get; set; }
        public static void CreateMessages(int messagesNumber, int pause, Storage storage) {
            int sequenceMessageNumber = 0;
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
