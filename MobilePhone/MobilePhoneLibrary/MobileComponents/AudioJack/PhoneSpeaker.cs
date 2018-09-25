using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.AudioJack {
    public class PhoneSpeaker : IPlayback {
        private IOutput Output;
        public PhoneSpeaker(IOutput output) {
            Output = output;
            Output.WriteLine($"{nameof(PhoneSpeaker)} playback selected");
        }
        public void Play() {
            Output.WriteLine("Play sound in Mobile:");
            Output.WriteLine($"{nameof(PhoneSpeaker)} sound");
        }
        public override string ToString() {
            return "PhoneSpeaker";
        }
    }
}
