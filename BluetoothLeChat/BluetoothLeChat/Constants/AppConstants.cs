using System;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Constants
{
    [Preserve(AllMembers = true)]
    public static class AppConstants
    {
        public const string BLEStateNotifier = "BLEStateNotifier";
        public const string UnauthorizedState = "Unauthorized Error with Bluetooth settings";
        public const string UnavailableState = "Unable to detect the Bluetooth configuration";
        public const string UnknownError = "Oops, Something Went Wrong";
        public const string BindableError = "Invalid bindable object is assigned";
        public const string TouchEffect = "BluetoothLeChat.TouchEffect";
        public const string EffectCommand = "BluetoothLeChat.EffectCommands";
        public const string ChildrenInputTransparent = "ChildrenInputTransparent";
        public const string Tap = "Tap";
        public const string TapParameter = "TapParameter";
        public const string LongTap = "LongTap";
        public const string LongTapParameter = "LongTapParameter";
    }
}
