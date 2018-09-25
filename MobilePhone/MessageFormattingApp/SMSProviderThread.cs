using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MobilePhone;

namespace MessageFormattingApp {
    internal class SMSProviderThread : SMSProvider {
        public SMSProviderThread():base() {}
        public Thread Start(int messageNumber, int pause, Storage storage) {
            Thread messageGenerator = new Thread(() => CreateMessages(messageNumber, pause,storage));
            messageGenerator.Start();
            return messageGenerator;
        }
        public void Stop(Thread messageGenerator) {
            messageGenerator.Abort();
        }
    }
}
