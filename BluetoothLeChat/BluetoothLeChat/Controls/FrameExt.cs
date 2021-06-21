using System;
using System.Linq;
using BluetoothLeChat.Constants;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Controls
{
    [Preserve(AllMembers = true)]
    public class FrameExt : Frame
    {
        #region Bindable Properties

        /// <summary>
        /// Bindable property for <see cref="ItemColor"/>
        /// </summary>
        public static readonly BindableProperty ItemColorProperty =
             BindableProperty.Create(nameof(ItemColor), typeof(Color), typeof(FrameExt), Color.FromHex("#D3D3D3"),
                 propertyChanged: OnItemColorChanged);

        #endregion

        #region Constructor

        public FrameExt()
        {
            this.BackgroundColor = ItemColor;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the background color for <see cref="FrameExt"/> to update it with animated effect.
        /// </summary>
        public Color ItemColor
        {
            get { return (Color)GetValue(ItemColorProperty); }
            set { SetValue(ItemColorProperty, value); }
        }

        #endregion

        #region Property Changed

        /// <summary>
        /// Notified when <see cref="ItemColor"/> property gets updated.
        /// </summary>
        /// <param name="bindable">Represents the <see cref="FrameExt"/>.</param>
        /// <param name="oldValue">Indicates the previous value of <see cref="ItemColor"/>.</param>
        /// <param name="newValue">Indicates the current value of <see cref="ItemColor"/>.</param>
        private static void OnItemColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is FrameExt frameExt)
            {
                frameExt.UpdateItemColor();
            }
            else
            {
                throw new Exception(AppConstants.BindableError);
            }
        }

        #endregion

        #region Private Methods

        async void UpdateItemColor()
        {
            //iOS platform does not support to change the bluetooth settings programmatically.
            //User need to modify from the device settings.
            if (Device.RuntimePlatform == Device.iOS) return;

            this.BackgroundColor = ItemColor;
            await this.ScaleTo(1.2, 100);
            await this.ScaleTo(1, 100);
        }

        #endregion
    }
}