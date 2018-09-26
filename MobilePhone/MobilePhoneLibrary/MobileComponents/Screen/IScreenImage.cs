using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public interface IScreenImage {
        int ImageHeight { get; set; }
        int ImageWidth { get; set; }
        void Draw(int imageHeight, int imageWidth);
    }
}
