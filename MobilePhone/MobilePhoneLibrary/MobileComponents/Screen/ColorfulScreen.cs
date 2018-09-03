using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public class ColorfulScreen : ScreenBase {
        public override int screenHeight {get; set;}
        public override int screenWidth {get; set;}
        public int colorDeep { get; set; }
        public override void Show(IScreenImage screenImage){
            Console.WriteLine("Colorful picture with height: " + screenImage.imageHeight + " and width: " + screenImage.imageWidth);
        }
        public override string ToString() { return "Colorful screen"; }
    }
}
