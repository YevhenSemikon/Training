using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone.MobileComponents.Microphone;
using MobilePhone.MobileComponents.Screen;
using MobilePhone.MobileComponents.Battery;
using MobilePhone.MobileComponents.Speaker;
using MobilePhone.MobileComponents.SimCard;

namespace MobilePhone {
    public class SimCorpMobilePhone : MobilePhone {
        public override ScreenBase Screen { get { return vOLEDScreen; } }
       // public override MicrophoneBase Microphone { get { return vNokiaMicrophone; } }
        public override BatteryBase Battery { get { return vLiPolBattery; } }
        public override SpeakerBase Speaker { get { return vStereoSpeaker; } }
        public override SimCardBase SimCard { get { return vSimCard; } }
        private readonly OLEDScreen vOLEDScreen = new OLEDScreen();
      //  private readonly NokiaMicrophone vNokiaMicrophone = new NokiaMicrophone();
        private readonly LiPolBattery vLiPolBattery = new LiPolBattery();
        private readonly StereoSpeaker vStereoSpeaker = new StereoSpeaker(30);
        private readonly SimCard4g vSimCard = new SimCard4g ();
    }
}
