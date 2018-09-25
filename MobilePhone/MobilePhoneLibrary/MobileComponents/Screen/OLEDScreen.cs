using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public class OLEDScreen : ScreenBase {
        private new int PPICoef = 60;
        public OLEDScreen() : base() { colorDepth = 12; }
        public int colorDepth { get; set; }
        public override double screenDiagonal { get; set; }
        public override int screenPPI { get { return getPPi(PPICoef); } }
        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("High quality image with height: " + screenImage.imageHeight + " and width: " + screenImage.imageWidth);
        }
        public override string ToString() { return "OLED Screen"; }
    }
}
