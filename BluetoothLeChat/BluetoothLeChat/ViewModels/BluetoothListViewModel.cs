using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BluetoothLeChat.Helper.Utils;
using BluetoothLeChat.Resources;
using BluetoothLeCore.Enum;
using Plugin.BLE.Abstractions.Contracts;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.ViewModels
{
    [Preserve(AllMembers = true)]
    public class BluetoothListViewModel : BaseViewModel
    {
        #region Fields

        bool isScanDeviceType, isScanning;
        ObservableCollection<IDevice> devices;
        IAdapter adapter;

        #endregion

        #region Constructor

        public BluetoothListViewModel(BLERequestType requestType) : base()
        {
            isScanDeviceType = requestType == BLERequestType.ScanDevice;
            Initialize();
        }

        #endregion

        #region Properties

        public bool ShowToolBar => isScanDeviceType;

        public string PageTitle => isScanDeviceType ? AppResources.AvailableDevices : AppResources.PairedDevices;

        public ObservableCollection<IDevice> Devices
        {
            get => devices;
            set
            {
                devices = value;
                OnPropertyChanged(nameof(Devices));
            }
        }

        public bool IsScanning
        {
            get => isScanning;
            set
            {
                isScanning = value;
                OnPropertyChanged(nameof(IsScanning));
            }
        }

        #endregion

        #region Commands

        public ICommand RefreshCommand { get; set; }

        #endregion

        #region Private Methods

        void Initialize()
        {
            IsLoading = true;
            RefreshCommand = new Command(() => RefreshScan());
            Devices = new ObservableCollection<IDevice>();
            adapter = BluetoothUtils.Instance.Adapter;
            adapter.ScanTimeout = 30000;
            //adapter.ScanMode = ScanMode.Passive | ScanMode.LowLatency | ScanMode.Balanced | ScanMode.LowPower;
            if (isScanDeviceType)
            {
                adapter.DeviceDiscovered += Adapter_DeviceDiscovered;
                adapter.ScanTimeoutElapsed += Adapter_ScanTimeoutElapsed;
                RefreshScan();
            }
            else
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    Devices = adapter.ConnectedDevices.ToObservableCollection();
                    IsScanning = IsLoading = false;
                });
            }
        }

        #endregion

        #region Callback Methods

        void Adapter_DeviceDiscovered(object sender, Plugin.BLE.Abstractions.EventArgs.DeviceEventArgs e)
        {
            if (!Devices.Contains(e.Device))
            {
                Devices.Add(e.Device);
            }

            IsLoading = false;
        }

        void Adapter_ScanTimeoutElapsed(object sender, EventArgs e)
        {
            adapter.StopScanningForDevicesAsync();
            IsScanning = IsLoading = false;
        }

        async void RefreshScan()
        {
            IsScanning = true;
            await adapter.StartScanningForDevicesAsync();
        }

        #endregion
    }
}

