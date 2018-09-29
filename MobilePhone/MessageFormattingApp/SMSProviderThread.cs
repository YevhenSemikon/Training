using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MobilePhone;

namespace MessageFormattingApp {
    internal class SMSProviderThread : SMSProvider {
        public SMSProviderThread() : base() { }
        public override void Start(Storage storage) {
            cancelMessageToken = new CancellationTokenSource();
            messageThreadGenerator = new Thread(() => CreateMessages(storage, cancelMessageToken.Token));
            messageThreadGenerator.Name = "Message Generator";
            messageThreadGenerator.Start();
        }
        public override void Stop() {
            cancelMessageToken.Cancel();
            Thread.Sleep(200);
        }
    }
}
