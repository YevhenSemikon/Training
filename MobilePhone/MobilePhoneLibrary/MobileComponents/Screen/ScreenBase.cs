using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public abstract class ScreenBase {
        public abstract int screenHeight {get; set;}
        public abstract int screenWidth {get; set;}
        public abstract int dpi { get; set; }
        public abstract void Show(IScreenImage screenImage);
    }
}
