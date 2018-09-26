using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public class OLEDScreen : ScreenBase {
        private new readonly int PPICoef = 60;
        public OLEDScreen() : base() { ColorDepth = 12; }
        public int ColorDepth { get; set; }
        public override double ScreenDiagonal { get; set; }
        public override int ScreenPPI { get { return GetPPi(PPICoef); } }
        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("High quality image with height: " + screenImage.ImageHeight + " and width: " + screenImage.ImageWidth);
        }
        public override string ToString() { return "OLED Screen"; }
    }
}
