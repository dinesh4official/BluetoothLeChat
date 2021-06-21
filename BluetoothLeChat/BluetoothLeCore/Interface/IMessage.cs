using System;
using Android.Runtime;

namespace BluetoothLeCore.Interface
{
    [PreserveAttribute(AllMembers = true)]
    public interface IMessage
    {
        void LongAlert(string message);

        void ShortAlert(string message);
    }
}
