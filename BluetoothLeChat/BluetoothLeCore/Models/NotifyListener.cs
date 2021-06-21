using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Android.Runtime;

namespace BluetoothLeCore.Models
{
    [PreserveAttribute(AllMembers = true)]
    public class NotifyListener : INotifyPropertyChanged
    {
        #region Constructor

        public NotifyListener()
        {

        }

        #endregion

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
