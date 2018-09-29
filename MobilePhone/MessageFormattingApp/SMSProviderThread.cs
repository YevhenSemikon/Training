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
        public void Start(Storage storage, CancellationToken token) {
            Thread messageGenerator = new Thread(() => CreateMessages(storage, token));
            messageGenerator.Name = "Message Ganerator";
            messageGenerator.Start();
            vMessageGeneratorThread = messageGenerator;
        }
    }
}
