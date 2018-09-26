using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public class MonochromeScreen : ScreenBase {
        public MonochromeScreen() : base() { }
        public override double ScreenDiagonal { get; set; }
        public override int ScreenPPI { get { return GetPPi(PPICoef); } }
        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("Black and white picture with height: " + screenImage.ImageHeight + " and width: " + screenImage.ImageWidth);
        }
        public override string ToString() { return "Monochrome screen"; }
    }
}
