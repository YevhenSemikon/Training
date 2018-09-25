using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public class MonochromeScreen : ScreenBase {
        public MonochromeScreen() : base() { }
        public override double screenDiagonal { get; set; }
        public override int screenPPI { get { return getPPi(PPICoef); } }
        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("Black and white picture with height: " + screenImage.imageHeight + " and width: " + screenImage.imageWidth);
        }
        public override string ToString() { return "Monochrome screen"; }
    }
}
