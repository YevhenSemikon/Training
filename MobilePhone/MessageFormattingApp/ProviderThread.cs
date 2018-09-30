using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MobilePhone;

namespace MessageFormattingApp {
    internal class ProviderThread : Provider {
        public ProviderThread() : base() { }
        public override void StartMessageCreation(Storage storage) {
            cancelMessageToken = new CancellationTokenSource();
            messageThreadGenerator = new Thread(() => CreateMessages(storage, cancelMessageToken.Token))
            {
                Name = "Message Generator"
            };
            messageThreadGenerator.Start();
        }
        public override void StopMessageCreation() {
            cancelMessageToken.Cancel();
            Thread.Sleep(200);
        }
        public override void StartCallsCreation(Storage storage)
        {
            cancelMessageToken = new CancellationTokenSource();
            callThreadGenerator = new Thread(() => CreateCalls(storage, cancelCallToken.Token))
            {
                Name = "Message Generator"
            };
            callThreadGenerator.Start();
        }
        public override void StopCallsCreation()
        {
            cancelCallToken.Cancel();
            Thread.Sleep(200);
        }
    }
}
