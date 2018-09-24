using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobilePhone.MobileComponents.AudioJack {
    public class iPhoneHeadset : IPlayback {
        private IOutput Output;
        public iPhoneHeadset(IOutput output) {
            Output = output;
            Output.WriteLine($"{nameof(iPhoneHeadset)} playback selected");
        }
        public void Play() {
            Output.WriteLine("Play sound in Mobile:");
            Output.WriteLine($"{nameof(iPhoneHeadset)} sound");
        }
        public override string ToString() {
            return "iPhoneHeadset";
        }
    }
}
