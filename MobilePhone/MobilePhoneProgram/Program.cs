using MobilePhone;
using MobilePhone.MobileComponents.Speaker;
using MobilePhone.MobileComponents.Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone.MobileComponents.Battery;

namespace MobilePhoneProgram {
    class Program {
        static void Main(string[] args){
            //SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            // string result=mobile.GetDescription();
            // Console.WriteLine(result);
            MonoSpeaker x = new MonoSpeaker();
            BatteryBase b = new LiIonBattery();
                    //  Console.WriteLine(b.capacity);
           // Console.WriteLine(x.power);
            Console.WriteLine(x.volume);
            x.VolumeUp(12);
            Console.WriteLine(x.channelsNumber);
            Console.WriteLine(x.volume);

        }
    }
}
