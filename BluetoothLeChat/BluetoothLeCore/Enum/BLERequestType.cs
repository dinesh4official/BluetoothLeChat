using System;
using Android.Runtime;

namespace BluetoothLeCore.Enum
{
    [PreserveAttribute(AllMembers = true)]
    public enum BLERequestType
    {
        ScanDevice,
        PairedDevice
    }
}
