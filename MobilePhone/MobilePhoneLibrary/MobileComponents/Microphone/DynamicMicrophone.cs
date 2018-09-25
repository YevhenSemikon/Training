using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Microphone {
    public class DynamicMicrophone : MicrophoneBase {
        public DynamicMicrophone() : base() { }
        public override int sensitivity { get; set; }
        public override int maxFrequency { get { return 5000; } }
        public override int minFrequency { get { return 500; } }
        public override string ToString() { return "Dynamic Microphone"; }
    }
}
