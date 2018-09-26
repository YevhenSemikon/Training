using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public class ColorfulScreen : ScreenBase {
        public ColorfulScreen() : base() { ColorDepth = 8; }
        public override double ScreenDiagonal { get; set; }
        public override int ScreenPPI { get { return GetPPi(PPICoef); } }
        public int ColorDepth { get; set; }
        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("Colorful picture with height: " + screenImage.ImageHeight + " and width: " + screenImage.ImageWidth);
        }
        public override string ToString() { return "Colorful screen"; }
    }
}
