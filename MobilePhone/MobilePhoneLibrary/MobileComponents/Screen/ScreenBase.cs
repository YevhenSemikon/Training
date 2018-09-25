using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public abstract class ScreenBase {
        protected int PPICoef = 50;
        public ScreenBase() { screenDiagonal = 3; }
        public abstract double screenDiagonal { get; set; }
        public abstract int screenPPI { get; }
        protected int getPPi(int PPICoef) {
            return Convert.ToInt32(screenDiagonal * PPICoef);
        }
        public abstract void Show(IScreenImage screenImage);
    }
}
