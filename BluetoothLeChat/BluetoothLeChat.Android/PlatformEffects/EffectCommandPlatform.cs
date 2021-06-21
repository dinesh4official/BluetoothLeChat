using System;
using Android.Views;
using BluetoothLeChat.Droid.PlatformEffects;
using BluetoothLeChat.Helper.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Rect = Android.Graphics.Rect;
using View = Android.Views.View;

[assembly: ExportEffect(typeof(EffectCommandPlatform), "EffectCommands")]
namespace BluetoothLeChat.Droid.PlatformEffects
{
     public class EffectCommandPlatform : PlatformEffect
    {
        #region Fields

        DateTime _tapTime;
        readonly Rect _rect = new Rect();
        readonly int[] _location = new int[2];

        #endregion

        #region Properties

        public View View => Control ?? Container;

        public bool IsDisposed => (Container as IVisualElementRenderer)?.Element == null;

        #endregion

        #region Override Methods

        protected override void OnAttached()
        {
            View.Clickable = true;
            View.LongClickable = true;
            View.SoundEffectsEnabled = true;
            TouchCollector.Add(View, OnTouch);
        }

        protected override void OnDetached()
        {
            if (IsDisposed) { return; }

            TouchCollector.Delete(View, OnTouch);
        }

        #endregion

        #region Methods

        void OnTouch(View.TouchEventArgs args)
        {
            switch (args.Event.Action)
            {
                case MotionEventActions.Down:
                    _tapTime = DateTime.Now;
                    break;

                case MotionEventActions.Up:
                    if (IsViewInBounds((int)args.Event.RawX, (int)args.Event.RawY))
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
            }
        }

        bool IsViewInBounds(int x, int y)
        {
            View.GetDrawingRect(_rect);
            View.GetLocationOnScreen(_location);
            _rect.Offset(_location[0], _location[1]);
            return _rect.Contains(x, y);
        }

        void ClickHandler()
        {
            var cmd = EffectCommand.GetTap(Element);
            var param = EffectCommand.GetTapParameter(Element);
            if (cmd?.CanExecute(param) ?? false)
            {
                cmd.Execute(param);
            }
        }

        void LongClickHandler()
        {
            var cmd = EffectCommand.GetLongTap(Element);

            if (cmd == null)
            {
                ClickHandler();
                return;
            }

            var param = EffectCommand.GetLongTapParameter(Element);
            if (cmd.CanExecute(param))
            {
                cmd.Execute(param);
            }
        }

        #endregion
    }
}
