using System;
using System.Collections.Generic;
using System.Text;

namespace MobilePhoneSimulator.Contract
{
    public interface IGprsReciever : ISignalReceiever
    {
        string Provider { get; }
    }
}
