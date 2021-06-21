using System;
using Xamarin.Forms.Internals;
using BluetoothLeCore.Interface;
using Android.Bluetooth;
using BluetoothLeChat.Droid.Dependency;

[assembly: Xamarin.Forms.Dependency(typeof(BluetoothService))]
namespace BluetoothLeChat.Droid.Dependency
{
    [Preserve(AllMembers = true)]
    public class BluetoothService : IBluetoothService
    {
        #region Constructor

        public BluetoothService()
        {

        }

        #endregion

        #region Interface Members

        public void EnableBluetooth()
        {
            BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            if(!bluetoothAdapter.IsEnabled)
            {
                bluetoothAdapter.Enable();
            }
        }


        public void DisableBluetooth()
        {
            BluetoothAdapter bluetoothAdapter = BluetoothAdapter.DefaultAdapter;
            if (bluetoothAdapter.IsEnabled)
            {
                bluetoothAdapter.Disable();
            }
        }

        #endregion
    }
}
