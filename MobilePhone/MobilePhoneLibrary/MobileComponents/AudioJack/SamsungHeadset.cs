using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.AudioJack {
    public class SamsungHeadset : IPlayback {
        private IOutput Output;
        public SamsungHeadset(IOutput output) {
            Output = output;
            Output.WriteLine($"{nameof(SamsungHeadset)} playback selected");
        }
        public void Play() {
            Output.WriteLine("Play sound in Mobile:");
            Output.WriteLine($"{nameof(SamsungHeadset)} sound");
        }
        public override string ToString() {
            return "SamsungHeadset";
        }
    }
}
