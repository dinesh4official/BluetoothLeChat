using System;
using System.Collections.ObjectModel;
using BluetoothLeChat.Constants;
using BluetoothLeCore.Enum;
using BluetoothLeCore.Interface;
using Plugin.BLE;
using Plugin.BLE.Abstractions.Contracts;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Helper.Utils
{
    [Preserve(AllMembers = true)]
    public sealed class BluetoothUtils : IBLEStateNotifier
    {
        #region ReadOnly Fields

        private static readonly Lazy<BluetoothUtils> lazyInstance = new Lazy<BluetoothUtils>(() => new BluetoothUtils());

        #endregion

        #region Constructor

        private BluetoothUtils()
        {
           
        }

        #endregion

        #region Properties

        public static BluetoothUtils Instance => lazyInstance.Value;

        public IAdapter Adapter => CrossBluetoothLE.Current.Adapter;

        #endregion

        #region Interface Member

        public BLEState CurrentBLEState { get => GetBLEState(CrossBluetoothLE.Current.State); set => throw new NotImplementedException(); }

        #endregion

        #region Public Methods

        public void WireDetectorEvent()
        {
            CrossBluetoothLE.Current.StateChanged += Current_StateChanged;
        }

        public void UnWireDetectorEvent()
        {
            CrossBluetoothLE.Current.StateChanged -= Current_StateChanged;
        }

        #endregion

        #region Private Methods

        void Current_StateChanged(object sender, Plugin.BLE.Abstractions.EventArgs.BluetoothStateChangedArgs e)
        {
            MessagingCenter.Send<IBLEStateNotifier, BLEState>(this, AppConstants.BLEStateNotifier, GetBLEState(CrossBluetoothLE.Current.State));
        }

        BLEState GetBLEState(BluetoothState bluetoothState)
        {
            switch(bluetoothState)
            {
                case BluetoothState.Unavailable:
                    return BLEState.Unavailable;
                case BluetoothState.Unauthorized:
                    return BLEState.Unauthorized;
                case BluetoothState.TurningOn:
                    return BLEState.TurningOn;
                case BluetoothState.On:
                    return BLEState.On;
                case BluetoothState.TurningOff:
                    return BLEState.TurningOff;
                case BluetoothState.Off:
                    return BLEState.Off;
                default:
                    return BLEState.Unknown;
            }
        }

        #endregion
    }
}

