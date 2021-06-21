using System;
using System.ComponentModel;
using System.Windows.Input;
using BluetoothLeChat.Helper.Effects;
using BluetoothLeChat.iOS.PlatformEffects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(EffectCommandPlatform), "EffectCommands")]
namespace BluetoothLeChat.iOS.PlatformEffects
{
    public class EffectCommandPlatform : PlatformEffect
    {
        #region Fields

        DateTime _tapTime;
        ICommand _tapCommand;
        ICommand _longCommand;
        object _tapParameter;
        object _longParameter;

        #endregion

        #region Properties

        public UIView View => Control ?? Container;

        #endregion

        #region Override Methods

        protected override void OnAttached()
        {
            View.UserInteractionEnabled = true;

            UpdateTap();
            UpdateTapParameter();
            UpdateLongTap();
            UpdateLongTapParameter();

            TouchCollector.Add(View, OnTouch);
        }

        protected override void OnDetached()
        {
            TouchCollector.Delete(View, OnTouch);
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == EffectCommand.TapProperty.PropertyName)
            {
                UpdateTap();
            }
            else if (args.PropertyName == EffectCommand.TapParameterProperty.PropertyName)
            {
                UpdateTapParameter();
            }
            else if (args.PropertyName == EffectCommand.LongTapProperty.PropertyName)
            {
                UpdateLongTap();
            }
            else if (args.PropertyName == EffectCommand.LongTapParameterProperty.PropertyName)
            {
                UpdateLongTapParameter();
            }
        }

        #endregion

        #region Methods

        void OnTouch(TouchGestureRecognizer.TouchArgs e)
        {
            switch (e.State)
            {
                case TouchGestureRecognizer.TouchState.Started:
                    _tapTime = DateTime.Now;
                    break;

                case TouchGestureRecognizer.TouchState.Ended:
                    if (e.Inside)
                    {
                        var range = (DateTime.Now - _tapTime).TotalMilliseconds;
                        if (range > 800)
                        {
                            LongClickHandler();
                        }
                        else
                        {
                            ClickHandler();
                        }
                    }
                    break;

                case TouchGestureRecognizer.TouchState.Cancelled:
                    break;
            }
        }

        void ClickHandler()
        {
            if (_tapCommand?.CanExecute(_tapParameter) ?? false)
            {
                _tapCommand.Execute(_tapParameter);
            }
        }

        void LongClickHandler()
        {
            if (_longCommand == null)
            {
                ClickHandler();
            }
            else if (_longCommand.CanExecute(_longParameter))
            {
                _longCommand.Execute(_longParameter);
            }
        }

        void UpdateTap()
        {
            _tapCommand = EffectCommand.GetTap(Element);
        }

        void UpdateTapParameter()
        {
            _tapParameter = EffectCommand.GetTapParameter(Element);
        }

        void UpdateLongTap()
        {
            _longCommand = EffectCommand.GetLongTap(Element);
        }

        void UpdateLongTapParameter()
        {
            _longParameter = EffectCommand.GetLongTapParameter(Element);
        }

        #endregion
    }
}
