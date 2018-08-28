using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public class OLEDScreen : ColorfulScreen {
        public override void Show(IScreenImage screenImage){
            Console.WriteLine("High quality image with height: " + screenImage.imageHeight + " and width: " + screenImage.imageWidth);
        }
    }
}
