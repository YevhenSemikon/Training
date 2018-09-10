using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.AudioJack {
    public class iPhoneHeadset : IPlayback {
        public void Play(object data) {
            Console.WriteLine($"{nameof(iPhoneHeadset)} sound");
        }
        public override string ToString() {
            return "iPhoneHeadset";
        }
    }
}
