using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Microphone {
   public class CondenserMicrophone : MicrophoneBase {
        public CondenserMicrophone() : base() { }
        public override int Sensitivity { get; set; }
        public override int MaxFrequency { get { return 15000; } }
        public override int MinFrequency { get { return 20; } }
        public override string ToString() { return "Condenser Microphone"; }
    }
}
