using System;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms.Internals;
using BluetoothLeChat.Constants;
using Microsoft.AppCenter.Distribute;
using BluetoothLeChat.Views;
using BluetoothLeChat.Helper.Utils;

namespace BluetoothLeChat
{
    [Preserve(AllMembers = true)]
    public partial class App : Application
    {
        #region Constructor

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new DashboardPage());
        }

        #endregion

        #region LifeCycle Overrides

        protected override void OnStart()
        {
            BluetoothUtils.Instance.WireDetectorEvent();
            AppCenter.Configure("android=" + AppKeyConstants.AppCenter_Android_SecretKey +
                "ios=" + AppKeyConstants.AppCenter_iOS_SecretKey);
            if (AppCenter.Configured)
            {
                AppCenter.Start(typeof(Analytics));
                AppCenter.Start(typeof(Crashes));
                AppCenter.Start(typeof(Distribute));
            }
        }

        protected override void OnSleep()
        {
            BluetoothUtils.Instance.UnWireDetectorEvent();
        }

        protected override void OnResume()
        {
            BluetoothUtils.Instance.WireDetectorEvent();
        }

        #endregion
    }
}
