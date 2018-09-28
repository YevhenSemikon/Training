using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MobilePhone;

namespace MessageFormattingApp {
    internal class SMSProvider {
        protected static int messagesNumber = 100;
        protected static int pause = 1000;
        public SMSProvider() {
            ProviderName = "KievProvider";
        }
        public string ProviderName { get; set; }
        public static void CreateMessages(Storage storage, CancellationToken token) {
            int sequenceMessageNumber = 0;
            for (int i = 0; i < messagesNumber; i++) {
                if (token.IsCancellationRequested) {
                    break;
                }
                storage.AddMessage(new Message("+380971234567", $"Message #{sequenceMessageNumber++} received!", DateTime.Now));
                System.Threading.Thread.Sleep(pause);
                storage.AddMessage(new Message("+380971234568", $"Message #{sequenceMessageNumber++} received!", DateTime.Now));
                System.Threading.Thread.Sleep(pause);
                storage.AddMessage(new Message("+380971234569", $"Message #{sequenceMessageNumber++} received!", DateTime.Now));
                System.Threading.Thread.Sleep(pause);
            }
        }
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
