using System;
using Android.Runtime;

namespace BluetoothLeCore.Interface
{
    [PreserveAttribute(AllMembers = true)]
    public interface IBluetoothService
    {
        void EnableBluetooth();

        void DisableBluetooth();
    }
}
