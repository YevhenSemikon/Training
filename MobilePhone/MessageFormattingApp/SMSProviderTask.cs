using MobilePhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessageFormattingApp {
    internal class SMSProviderTask : SMSProvider {
        public SMSProviderTask() : base() { }
        public override void Start(Storage storage) {
            cancelMessageToken = new CancellationTokenSource();
            messageTaskGenerator = Task.Factory.StartNew(() => CreateMessages(storage, cancelMessageToken.Token));
        }
        public override void Stop() {
            cancelMessageToken.Cancel();
            Thread.Sleep(200);
        }
    }
}
