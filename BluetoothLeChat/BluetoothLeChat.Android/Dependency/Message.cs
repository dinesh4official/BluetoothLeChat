using System;
using Android.App;
using Android.Widget;
using BluetoothLeChat.Droid.Dependency;
using BluetoothLeCore.Interface;
using Xamarin.Forms.Internals;

[assembly: Xamarin.Forms.Dependency(typeof(Message))]
namespace BluetoothLeChat.Droid.Dependency
{
    [Preserve(AllMembers = true)]
    public class Message : IMessage
    {
        #region Constructor

        public Message()
        {

        }

        #endregion

        #region Interface Methods

        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }

        #endregion
    }
}
