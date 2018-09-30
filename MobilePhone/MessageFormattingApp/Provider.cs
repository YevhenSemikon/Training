using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MobilePhone;
using MobilePhone.CommonUtilities;

namespace MessageFormattingApp {
    internal class Provider {
        protected CancellationTokenSource cancelMessageToken = new CancellationTokenSource();
        protected CancellationTokenSource cancelCallToken = new CancellationTokenSource();
        internal Thread messageThreadGenerator;
        internal Task messageTaskGenerator;
        internal Thread callThreadGenerator;
        internal Task callTaskGenerator;
        static AutoResetEvent waitHandler = new AutoResetEvent(true);
        protected static int messagesNumber = 100;
        protected static int callsNumber = 100;
        protected static int pause = 1000;

        public Provider() {
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

        public static void CreateCalls(Storage storage,CancellationToken token)
        {
            for (int i = 0; i < callsNumber; i++)
            {
                List<Call> calls = new List<Call>
                {
                    new Call(Direction.Incoming, DateTime.Now, new Contact("Jane", "Spring", 20, "+380931234567"))
                };
                Thread.Sleep(pause);
                calls.Add(new Call(Direction.Incoming, DateTime.Now, new Contact("Dart", "Spring", 20, "+380931234568")));
                Thread.Sleep(pause);
                calls.Add(new Call(Direction.Outgoing, DateTime.Now, new Contact("Bred", "Spring", 21, "+380931234569")));
                Thread.Sleep(pause);
                calls.Add(new Call(Direction.Outgoing, DateTime.Now, new Contact("Bred", "Spring", 21, "+380931234567")));
                Thread.Sleep(pause);
                calls.Add(new Call(Direction.Incoming, DateTime.Now, new Contact("Dart", "Spring", 21, "+380931234569")));
                Thread.Sleep(pause);
                calls.Add(new Call(Direction.Incoming, DateTime.Now, new Contact("Dart", "Spring", 21, "+380931234569")));
                Thread.Sleep(pause);
                foreach (Call call in calls) {
                  if (token.IsCancellationRequested) { return; }                  
                  storage.AddCall(call);
                }
            }
        }

        public virtual void StartMessageCreation(Storage storage) { }
        public virtual void StopMessageCreation() { }
        public virtual void StartCallsCreation(Storage storage) { }
        public virtual void StopCallsCreation() { }
    }
}
