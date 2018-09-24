using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.AudioJack {
    public class UnofficialiPhoneHeadset : IPlayback {
        private IOutput Output;
        public UnofficialiPhoneHeadset(IOutput output) {
            Output = output;
            Output.WriteLine($"{nameof(UnofficialiPhoneHeadset)} playback selected");
        }
        public void Play() {
            Output.WriteLine("Play sound in Mobile:");
            Output.WriteLine($"{nameof(UnofficialiPhoneHeadset)} sound");
        }
        public override string ToString() {
            return "UnofficialiPhoneHeadset";
        }
    }
}
