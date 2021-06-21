using System;
using BluetoothLeCore.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Helper.Utils
{
    [Preserve(AllMembers = true)]
    public static class AppUtils
    {
        #region Public Methods

        public static void ShowAlert(string message, bool isLong)
        {
            if (isLong)
            {
                DependencyService.Get<IMessage>().LongAlert(message);
            }
            else
            {
                DependencyService.Get<IMessage>().ShortAlert(message);
            }
        }

        public static void ChangeBLEStatus(bool needToEnable)
        {
            if (needToEnable)
            {
                DependencyService.Get<IBluetoothService>().EnableBluetooth();
            }
            else
            {
                DependencyService.Get<IBluetoothService>().DisableBluetooth();
            }
        }

        #endregion
    }
}
