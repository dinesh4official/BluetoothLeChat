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
        void OnItemPressed(object itemType)
        {
            int type = int.Parse(itemType.ToString());
            if(type == 0)
            {

            }
        }

        #endregion
    }
}
