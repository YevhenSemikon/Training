using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public class RetinaScreen : ScreenBase {
        protected new int PPICoef = 80;
        public RetinaScreen() : base() { ColorDepth = 24; }
        public int ColorDepth { get; set; }
        public override double ScreenDiagonal { get; set; }
        public override int ScreenPPI { get { return GetPPi(PPICoef); } }
        public override void Show(IScreenImage screenImage) {
            Console.WriteLine("Super high quality image with height: " + screenImage.ImageHeight + " and width: " + screenImage.ImageWidth);
        }
        public override string ToString() { return "Retina Screen"; }
    }
}
