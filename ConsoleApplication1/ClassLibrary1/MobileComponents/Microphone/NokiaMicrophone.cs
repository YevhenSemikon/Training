using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Microphone {
    public class NokiaMicrophone : MicrophoneBase {
        public override int sensitivity { get; set; }
        public override void Mute(bool mute){
            if (mute) { Console.WriteLine("Nokia microphone is muted"); }
            else { Console.WriteLine("Nokia microphone is unmuted"); }
        }
        public override string ToString() { return "Nokia Microphone"; }
    }
}
