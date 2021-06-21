using System;
using Android.Runtime;
using BluetoothLeCore.Enum;

namespace BluetoothLeCore.Interface
{
    [PreserveAttribute(AllMembers = true)]
    public interface IBLEStateNotifier
    {
        BLEState CurrentBLEState { get; set; }
    }
}