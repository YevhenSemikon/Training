using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Speaker {
    public class StereoSpeaker : SpeakerBase {
        public StereoSpeaker() : base() { }
        public StereoSpeaker(int currentVolume) : base() { this.currentVolume = currentVolume; }
        public int volume { get { return currentVolume; } }
        public override int power { get; set; }
        public int channelsNumber { get { return 2; } }
        public override string ToString() { return "Stereo-Speaker"; }
    }
}
