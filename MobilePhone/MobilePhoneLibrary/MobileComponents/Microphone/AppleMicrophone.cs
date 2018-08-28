using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Microphone {
   public class AppleMicrophone : MicrophoneBase {
        public override int sensitivity { get; set; }
        public override void Mute(bool mute){
            if (mute) { Console.WriteLine("Apple microphone is muted"); }
            else { Console.WriteLine("Apple microphone is unmuted"); }
        }
        public override string ToString() { return "Apple Microphone"; }
    }
}
