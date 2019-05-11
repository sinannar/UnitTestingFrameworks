using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneSimulator.Contract
{
    public interface IPhoneSimulator
    {
        bool IsWireless { get; }
        bool IsGprs { get; }
    }
}
