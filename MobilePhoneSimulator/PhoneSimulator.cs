using MobilePhoneSimulator.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneSimulator
{
    public class PhoneSimulator : IPhoneSimulator
    {
        private IWirelessReceiever _wirelessAntenna;
        private IGprsReciever _gprsAntenna;

        public PhoneSimulator(IWirelessReceiever wirelessAntenna, IGprsReciever gprsAntenna)
        {
            _wirelessAntenna = wirelessAntenna;
            _gprsAntenna = gprsAntenna;
        }

        public bool IsWireless
        {
            get
            {
                return _wirelessAntenna.IsConnected && _wirelessAntenna.SignalStrength > 500;
            }
        }
        public bool IsGprs
        {
            get
            {
                return !IsWireless && _gprsAntenna.SignalStrength > 100;
            }
        }
    }
}
