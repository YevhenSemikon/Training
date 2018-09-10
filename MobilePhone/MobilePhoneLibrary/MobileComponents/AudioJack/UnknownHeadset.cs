using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.AudioJack {
    public class UnknownHeadset : IPlayback {
        public void Play(object data) {
            throw new NotImplementedException();
        }
        public override string ToString() {
            return "UnknownHeadset";
        }
    }
}
