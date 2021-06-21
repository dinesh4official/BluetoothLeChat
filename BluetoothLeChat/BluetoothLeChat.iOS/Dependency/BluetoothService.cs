using System;
using BluetoothLeCore.Interface;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(IBluetoothService))]
namespace BluetoothLeChat.iOS.Dependency
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
            OpenAppSettings();
        }


        public void DisableBluetooth()
        {
            OpenAppSettings();
        }

        #endregion

        #region Private Methods

        private void OpenAppSettings()
        {
            UIApplication.SharedApplication.OpenUrl(new NSUrl(UIApplication.OpenSettingsUrlString), new NSDictionary(), null);
        }

        #endregion
    }
}
