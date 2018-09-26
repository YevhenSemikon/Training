using System;
using System.Threading;

namespace MobilePhone.MobileComponents.Battery
{
    public delegate void ChargeLevelChange(int currentChargeLevel);
    public class ChargeLevel
    {

        public event ChargeLevelChange ChargingOn;
        public event ChargeLevelChange ChargingOff;
        public ChargeLevel(int currentChargeLevel)
        {
            CurrentChargeLevel = currentChargeLevel;
        }
        public int CurrentChargeLevel { get; private set; }

        internal void Charging(MobilePhone mobile)
        {
            while(CurrentChargeLevel < 100)
            {
                CurrentChargeLevel += 1;
                ChargingOn?.Invoke(CurrentChargeLevel);
                int chargingTime = Convert.ToInt32(1000 * mobile.ChargerComponent.ChargerCoef * mobile.Battery.BatteryChargeCoef);
                Thread.Sleep(chargingTime);
            }
           
        }
        internal void DisCharging(MobilePhone mobile)
        {
            while (CurrentChargeLevel > 0)
            {
                CurrentChargeLevel -= 1;
                ChargingOff?.Invoke(CurrentChargeLevel);
                int chargingTime = Convert.ToInt32(3000 * mobile.Battery.BatteryDisChargeCoef);
                Thread.Sleep(chargingTime);               
            }
        }
    }
}