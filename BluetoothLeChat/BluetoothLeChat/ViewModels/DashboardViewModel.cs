using System;
using System.Windows.Input;
using BluetoothLeChat.Helper.Utils;
using BluetoothLeChat.Resources;
using BluetoothLeCore.Enum;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.ViewModels
{
    [Preserve(AllMembers = true)]
    public class DashboardViewModel : BaseViewModel
    {
        #region Constructor

        public DashboardViewModel()
        {
            BLEStatusCommand = new Command(() => UpdateBLEStatus());
            ItemCommand = new Command<object>((itemType) => OnItemPressed(itemType));
        }

        #endregion

        #region Commands

        public ICommand BLEStatusCommand { get; set; }

        public ICommand ItemCommand { get; set; }

        #endregion

        #region Private Methods

        void UpdateBLEStatus()
        {
            AppUtils.ChangeBLEStatus(!IsBluetoothON);
        }

        /// <summary>
        /// Raise when the card item in the dashboard is pressed.
        /// </summary>
        /// <param name="itemType">
        /// 0 -> Indicates Scan item and 1 -> Indicates Paired item.
        /// </param>
        async void OnItemPressed(object itemType)
        {
            if (!IsBluetoothON)
            {
                AppUtils.ShowAlert(AppResources.EnableBluetooth, true);
                return;
            }

            PermissionStatus permissionStatus = await PermissionUtils.Instance.CheckAndRequestLocationPermission();
            if (permissionStatus != PermissionStatus.Granted)
            {
                AppUtils.ShowAlert(AppResources.LocationPermissionDenied, false);
            }

            int type = int.Parse(itemType.ToString());
            BLERequestType requestType = type == 0
                ? BLERequestType.ScanDevice : BLERequestType.PairedDevice;
            AppUtils.PushAsync(AppUtils.GetPageFromRoute
                (Helper.Enum.AppRoute.BluetoothList,
                new BluetoothListViewModel(requestType)));
        }

        #endregion
    }
}
