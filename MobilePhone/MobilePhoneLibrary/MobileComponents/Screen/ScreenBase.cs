using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Screen {
    public abstract class ScreenBase {
        protected int PPICoef = 50;
        public ScreenBase() { ScreenDiagonal = 3; }
        public abstract double ScreenDiagonal { get; set; }
        public abstract int ScreenPPI { get; }
        protected int GetPPi(int PPICoef) {
            return Convert.ToInt32(ScreenDiagonal * PPICoef);
        }
        public abstract void Show(IScreenImage screenImage);
    }
}
