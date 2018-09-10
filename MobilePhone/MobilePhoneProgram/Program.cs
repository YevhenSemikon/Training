using MobilePhone;
using MobilePhone.MobileComponents.Speaker;
using MobilePhone.MobileComponents.Screen;
using MobilePhone.MobileComponents.SimCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone.MobileComponents.Battery;
using MobilePhone.MobileComponents.AudioJack;

namespace MobilePhoneProgram {
    class Program {
        static void Main(string[] args){
           SimCorpMobilePhone mobile = new SimCorpMobilePhone();
           Console.WriteLine(mobile.GetDescription());
            IPlayback playbackComponent=SelectPlaybackComponent();
            mobile.PlaybackComponent = playbackComponent;
            mobile.Play(mobile.PlaybackComponent);
        }

        private static IPlayback SelectPlaybackComponent()
        {
            IPlayback playbackComponent;
            var text = new StringBuilder();
            text.Append("Select playback component (specify index): " + System.Environment.NewLine);
            text.Append("1 - iPhoneHeadset" + System.Environment.NewLine);
            text.Append("2 - SamsungHeadset" + System.Environment.NewLine);
            text.Append("3 - UnofficialiPhoneHeadset" + System.Environment.NewLine);
            text.Append("4 - PhoneSpeaker");
            Console.WriteLine(text.ToString());
            string playbackIndex=Console.ReadLine();
            switch (playbackIndex) {
                case "1":
                 playbackComponent = new iPhoneHeadset();
                break;
                case "2":
                playbackComponent = new SamsungHeadset();
                break;
                case "3":
                playbackComponent = new UnofficialiPhoneHeadset();
                break;
                case "4":
                playbackComponent = new PhoneSpeaker();
                break; 
              default:
                playbackComponent = new UnknownHeadset();
                break;
            }
            Console.WriteLine(playbackComponent.ToString() + " playback selected");
            return playbackComponent;
        }
    }
}
