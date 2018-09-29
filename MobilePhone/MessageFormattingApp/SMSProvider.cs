using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MobilePhone;

namespace MessageFormattingApp {
    internal class SMSProvider {
        protected CancellationTokenSource cancelMessageToken = new CancellationTokenSource();
        internal Thread messageThreadGenerator;
        internal Task messageTaskGenerator;
        static AutoResetEvent waitHandler = new AutoResetEvent(true);
        protected static int messagesNumber = 100;
        protected static int pause = 1000;
        public SMSProvider() {
            ProviderName = "KievProvider";
        }
        public string ProviderName { get; set; }
        protected void CreateMessages(Storage storage, CancellationToken token) {
            waitHandler.WaitOne();
            int sequenceMessageNumber = 0;
            for (int i = 0; i < messagesNumber; i++) {
                List<Message> messages = new List<Message>() {
                new Message("+380971234567", $"Message #{sequenceMessageNumber++} received!", DateTime.Now),
                new Message("+380971234568", $"Message #{sequenceMessageNumber++} received!", DateTime.Now.AddMinutes(1)),
                new Message("+380971234569", $"Message #{sequenceMessageNumber++} received!", DateTime.Now.AddMinutes(2))
             };
                foreach (Message message in messages) {
                    if (token.IsCancellationRequested) {
                        waitHandler.Set();
                        return;
                    }
                    storage.AddMessage(message);
                    System.Threading.Thread.Sleep(pause);
                }
            }
            waitHandler.Set();
        }
        public static void CreateMessages(int messagesNumber, int pause, Storage storage) {
            int sequenceMessageNumber = 0;
            for (int i = 0; i < messagesNumber; i++) {
                List<Message> messages = new List<Message>() {
                new Message("+380971234567", $"Message #{sequenceMessageNumber++} received!", DateTime.Now),
                new Message("+380971234568", $"Message #{sequenceMessageNumber++} received!", DateTime.Now.AddMinutes(1)),
                new Message("+380971234569", $"Message #{sequenceMessageNumber++} received!", DateTime.Now.AddMinutes(2))
             };
                foreach (Message message in messages) {
                    storage.AddMessage(message);
                    System.Threading.Thread.Sleep(pause);
                }
            }
        }
        public virtual void Start(Storage storage) { }
        public virtual void Stop() { }
    }
}
