using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MobilePhone.MobileComponents.Screen {
    public class BaseImage : IScreenImage {
        private int imageHeight;
        private int imageWidth;
        public int ImageHeight { get { return imageHeight; } set { imageHeight = value; } }
        public int ImageWidth { get { return imageWidth; } set { imageWidth = value; } }
        public void Draw(int imageHeight, int imageWidth) {
            Console.WriteLine("Draw picture with: Height: " + imageHeight + " and Width: " + imageWidth);
        }
    }
}
