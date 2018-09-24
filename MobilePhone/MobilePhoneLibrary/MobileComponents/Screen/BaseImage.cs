using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MobilePhone.MobileComponents.Screen {
    public class BaseImage : IScreenImage {
        private int imageheight;
        private int imagewidth;
        public int imageHeight { get { return imageheight; } set { imageheight = value; } }
        public int imageWidth { get { return imagewidth; } set { imagewidth = value; } }
        public void Draw(int imageHeight, int imageWidth) {
            Console.WriteLine("Draw picture with: Height: " + imageHeight + " and Width: " + imageWidth);
        }
    }
}
