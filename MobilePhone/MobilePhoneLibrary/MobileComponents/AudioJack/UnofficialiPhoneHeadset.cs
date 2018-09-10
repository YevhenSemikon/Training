using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.AudioJack {
    public class UnofficialiPhoneHeadset : IPlayback {
        public void Play(object data) {
            Console.WriteLine($"{nameof(UnofficialiPhoneHeadset)} sound");
        }
        public override string ToString() {
            return "UnofficialiPhoneHeadset";
        }
    }
}
