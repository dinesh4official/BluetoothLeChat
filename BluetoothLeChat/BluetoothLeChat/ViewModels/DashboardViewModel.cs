using System;
using System.Windows.Input;
using BluetoothLeChat.Helper.Utils;
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
        }

        #endregion

        #region Commands

        public ICommand BLEStatusCommand { get; set; }

        #endregion

        #region Private Methods

        void UpdateBLEStatus()
        {
            AppUtils.ChangeBLEStatus(!IsBluetoothON);
        }

        #endregion
    }
}
