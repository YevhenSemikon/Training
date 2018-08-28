using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Microphone {
    public abstract class MicrophoneBase {
        public abstract int sensitivity {get; set;}
        public abstract void Mute(bool mute);
    }
}
