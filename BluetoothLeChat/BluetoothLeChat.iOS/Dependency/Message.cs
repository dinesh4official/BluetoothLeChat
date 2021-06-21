using System;
using Foundation;
using UIKit;
using BluetoothLeChat.iOS.Dependency;
using BluetoothLeCore.Interface;

[assembly: Xamarin.Forms.Dependency(typeof(Message))]
namespace BluetoothLeChat.iOS.Dependency
{
    [Preserve(AllMembers = true)]
    public class Message : IMessage
    {
        #region Fields

        const double longdelay = 3.5;
        const double shortdelay = 0.75;

        #endregion

        #region Constructor

        public Message()
        {

        }

        #endregion

        #region Interface Methods

        public void LongAlert(string message)
        {
            DisplayAlert(message, longdelay);
        }

        public void ShortAlert(string message)
        {
            DisplayAlert(message, shortdelay);
        }

        #endregion

        #region Private Methods

        void DisplayAlert(string message, double seconds)
        {
            var alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);

            var alertDelay = NSTimer.CreateScheduledTimer(seconds, obj =>
            {
                DismissAlert(alert, obj);
            });

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void DismissAlert(UIAlertController alert, NSTimer alertDelay)
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }

            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }

        #endregion
    }
}