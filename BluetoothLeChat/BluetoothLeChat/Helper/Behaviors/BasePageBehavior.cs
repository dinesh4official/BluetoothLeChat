using System;
using System.Threading.Tasks;
using BluetoothLeChat.Helper.Utils;
using BluetoothLeChat.Resources;
using BluetoothLeChat.Views;
using Xamarin.Essentials;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Helper.Behaviors
{
    [Preserve(AllMembers = true)]
    public class BasePageBehavior : BehaviorBase<BasePage>
    {
        #region Constructor

        public BasePageBehavior()
        {

        }

        #endregion

        #region Override Methods

        protected override void OnAttachedTo(BasePage bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.Appearing += Bindable_Appearing;
        }

        protected override void OnDetachingFrom(BasePage bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.Appearing -= Bindable_Appearing;
        }

        #endregion

        #region Callback Methods

        private async void Bindable_Appearing(object sender, EventArgs e)
        {
            await Task.Delay(100);
            PermissionStatus permissionStatus = await PermissionUtils.Instance.CheckAndRequestLocationPermission();
            if (permissionStatus != PermissionStatus.Granted)
            {
                AppUtils.ShowAlert(AppResources.LocationPermissionDenied, false);
            }
        }

        #endregion
    }
}
