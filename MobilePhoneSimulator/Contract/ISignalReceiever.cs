using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneSimulator.Contract
{
    public interface ISignalReceiever
    {
        decimal SignalStrength { get; }
    }
}
