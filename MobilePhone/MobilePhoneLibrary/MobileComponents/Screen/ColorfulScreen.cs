using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public class ColorfulScreen : ScreenBase {
        public ColorfulScreen() : base() { colorDepth = 8; }
        public override double screenDiagonal { get; set; }
        public override int screenPPI { get { return getPPi(PPICoef); } }
        public int colorDepth { get; set; }
        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("Colorful picture with height: " + screenImage.imageHeight + " and width: " + screenImage.imageWidth);
        }
        public override string ToString() { return "Colorful screen"; }
    }
}
