using MobilePhone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MessageFormattingApp {
    internal class SMSProviderTask : SMSProvider {
        public SMSProviderTask():base() { }
        public void Start(Storage storage,CancellationToken token) {
            Task messageGenerator = Task.Factory.StartNew(() => CreateMessages(storage,token));
            vMessageGeneratorTask = messageGenerator;           
        }
    }
}
