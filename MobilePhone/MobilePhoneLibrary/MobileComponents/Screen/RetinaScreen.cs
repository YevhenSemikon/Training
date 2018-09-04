using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public class RetinaScreen : ScreenBase {
        protected new int PPICoef = 80;
        public RetinaScreen() : base() { colorDepth = 24; }
        public int colorDepth { get; set; }
        public override double screenDiagonal { get; set; }
        public override int screenPPI { get { return getPPi(PPICoef); } }
        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("Super high quality image with height: " + screenImage.imageHeight + " and width: " + screenImage.imageWidth);
        }
        public override string ToString() { return "Retina Screen"; }
    }
}
