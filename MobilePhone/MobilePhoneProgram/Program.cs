using MobilePhone;
using MobilePhone.MobileComponents.Speaker;
using MobilePhone.MobileComponents.Screen;
using MobilePhone.MobileComponents.SimCard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhone.MobileComponents.Battery;

namespace MobilePhoneProgram {
    class Program {
        static void Main(string[] args){
            SimCorpMobilePhone mobile = new SimCorpMobilePhone();
            Console.WriteLine(mobile.GetDescription());   
        }
    }
}
