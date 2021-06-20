using System;
using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms.Internals;
using BluetoothLeChat.Constants;
using Microsoft.AppCenter.Distribute;

namespace BluetoothLeChat
{
    [Preserve(AllMembers = true)]
    public partial class App : Application
    {
        #region Constructor

        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        #endregion

        #region LifeCycle Overrides

        protected override void OnStart()
        {
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

        }

        protected override void OnResume()
        {
        }

        #endregion
    }
}
