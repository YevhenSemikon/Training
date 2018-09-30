using MobilePhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessageFormattingApp {
    internal class ProviderTask : Provider {
        public ProviderTask() : base() { }
        public override void StartMessageCreation(Storage storage) {
            cancelMessageToken = new CancellationTokenSource();
            messageTaskGenerator = Task.Factory.StartNew(() => CreateMessages(storage, cancelMessageToken.Token));
        }
        public override void StopMessageCreation() {
            cancelMessageToken.Cancel();
            Thread.Sleep(200);
        }
        public override void StartCallsCreation(Storage storage)
        {
            cancelCallToken = new CancellationTokenSource();
            callTaskGenerator = Task.Factory.StartNew(() => CreateCalls(storage, cancelCallToken.Token));
        }
        public override void StopCallsCreation()
        {
            cancelCallToken.Cancel();
            Thread.Sleep(200);
        }
    }
}
