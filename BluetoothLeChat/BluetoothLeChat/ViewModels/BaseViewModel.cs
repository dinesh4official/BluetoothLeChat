using System;
using BluetoothLeChat.Constants;
using BluetoothLeChat.Helper.Utils;
using BluetoothLeChat.Resources;
using BluetoothLeCore.Enum;
using BluetoothLeCore.Interface;
using BluetoothLeCore.Models;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.ViewModels
{
    [Preserve(AllMembers = true)]
    public class BaseViewModel : NotifyListener, IBLEStateNotifier
    {
        #region Fields

        BLEState state;
        bool isBluetoothON, isLoading;

        #endregion

        #region Constructor

        public BaseViewModel()
        {
            SubscribeBLEStateNotifier();
            CurrentBLEState = BluetoothUtils.Instance.CurrentBLEState;
        }

        #endregion

        #region Properties

        public bool IsBluetoothON
        {
            get => isBluetoothON;
            private set
            {
                if (IsBluetoothON == value) { return; }

                isBluetoothON = value;
                OnPropertyChanged(nameof(IsBluetoothON));
            }
        }

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                if (isLoading == value) { return; }

                isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        #endregion

        #region Interface Member

        public BLEState CurrentBLEState
        {
            get => state;
            set
            {
                if (state == value) { return; }

                state = value;
                ValidateBLEState();
                OnPropertyChanged(nameof(CurrentBLEState));
            }
        }

        #endregion

        #region BLEState Notifier

        private void SubscribeBLEStateNotifier()
        {
            MessagingCenter.Subscribe<IBLEStateNotifier, BLEState>(this, AppConstants.BLEStateNotifier, (sender, arg) =>
            {
                CurrentBLEState = arg;
            });
        }

        #endregion

        #region Private Methods

        void ValidateBLEState()
        {
            string message = string.Empty;
            if (state == BLEState.Unauthorized)
            {
                message = AppResources.UnauthorizedState;
            }
            else if (state == BLEState.Unavailable)
            {
                message = AppResources.UnavailableState;
            }
            else if (state == BLEState.Unknown)
            {
                message = AppResources.UnknownError;
            }
            else if (state == BLEState.TurningOn || state == BLEState.On)
            {
                IsBluetoothON = true;
            }
            else if (state == BLEState.TurningOff || state == BLEState.Off)
            {
                IsBluetoothON = false;
            }

            if (!string.IsNullOrEmpty(message))
            {
                IsBluetoothON = false;
                AppUtils.ShowAlert(message, false);
            } 
        }

        #endregion
    }
}
