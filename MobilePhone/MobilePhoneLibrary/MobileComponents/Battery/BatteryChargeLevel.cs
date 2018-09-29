using MobilePhone.MobileComponents.Charger;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MobilePhone.MobileComponents.Battery {
    public abstract class BatteryChargeLevel {
        public Thread vChargingThread;
        public Thread vDisChargingThread;
        public Task vChargingTask;
        public Task vDisChargingTask;
        public delegate void ChargeLevelChange(int currentChargeLevel);
        public event ChargeLevelChange OnChargingLevelChange;
        internal BatteryChargeLevel(int currentChargeLevel) {
            CurrentChargeLevel = currentChargeLevel;
        }
        internal BatteryChargeLevel() {
            CurrentChargeLevel = 30;
        }
        public int CurrentChargeLevel { get; private set; }

        internal void Charging(ICharge charger, BatteryBase battery, CancellationToken token) {
            while (CurrentChargeLevel < 100) {
                int chargingTime = Convert.ToInt32(1000 * battery.BatteryCharger.ChargerCoef * battery.BatteryChargeCoef);
                Thread.Sleep(chargingTime);
                lock (this) {
                    if (token.IsCancellationRequested) { break; }
                    CurrentChargeLevel += 1;
                    OnChargingLevelChange?.Invoke(CurrentChargeLevel);
                }
            }
        }

        internal void DisCharging(BatteryBase battery, CancellationToken token) {
            while (CurrentChargeLevel > 0) {
                int disChargingTime = Convert.ToInt32(3000 * battery.BatteryDisChargeCoef);
                Thread.Sleep(disChargingTime);
                lock (this) {
                    if (token.IsCancellationRequested) { break; }
                    CurrentChargeLevel -= 1;
                    OnChargingLevelChange?.Invoke(CurrentChargeLevel);
                }
            }
        }

        public abstract void StartDisCharging(BatteryBase battery, CancellationToken token);
        public abstract void StartCharging(ICharge charger, BatteryBase battery, CancellationToken token);
    }
}
