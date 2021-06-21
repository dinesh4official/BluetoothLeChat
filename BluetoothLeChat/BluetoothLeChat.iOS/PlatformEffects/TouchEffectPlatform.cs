using System;
using System.ComponentModel;
using BluetoothLeChat.Helper.Effects;
using BluetoothLeChat.iOS.PlatformEffects;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportEffect(typeof(TouchEffectPlatform), "TouchEffect")]
namespace BluetoothLeChat.iOS.PlatformEffects
{
    public class TouchEffectPlatform : PlatformEffect
    {
        #region Fields

        UIView _layer;
        nfloat _alpha;

        #endregion

        #region Properties

        public bool IsDisposed => (Container as IVisualElementRenderer)?.Element == null;

        public UIView View => Control ?? Container;

        #endregion

        #region Override Methods

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(e);

            if (e.PropertyName == TouchEffect.ColorProperty.PropertyName)
            {
                UpdateEffectColor();
            }
        }

        protected override void OnAttached()
        {
            View.UserInteractionEnabled = true;
            _layer = new UIView
            {
                UserInteractionEnabled = false,
                Opaque = false,
                Alpha = 0,
                TranslatesAutoresizingMaskIntoConstraints = false
            };

            UpdateEffectColor();
            TouchCollector.Add(View, OnTouch);

            View.AddSubview(_layer);
            View.BringSubviewToFront(_layer);
            _layer.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
            _layer.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
            _layer.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;
            _layer.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
        }

        protected override void OnDetached()
        {
            TouchCollector.Delete(View, OnTouch);
            _layer?.RemoveFromSuperview();
            _layer?.Dispose();
        }

        #endregion

        #region Methods

        void OnTouch(TouchGestureRecognizer.TouchArgs e)
        {
            switch (e.State)
            {
                case TouchGestureRecognizer.TouchState.Started:
                    BringLayer();
                    break;

                case TouchGestureRecognizer.TouchState.Ended:
                    EndAnimation();
                    break;

                case TouchGestureRecognizer.TouchState.Cancelled:
                    if (!IsDisposed && _layer != null)
                    {
                        _layer.Layer.RemoveAllAnimations();
                        _layer.Alpha = 0;
                    }

                    break;
            }
        }

        void UpdateEffectColor()
        {
            var color = TouchEffect.GetColor(Element);
            if (color == Color.Default)
            {
                return;
            }

            _alpha = color.A < 1.0 ? 1 : (nfloat)0.3;
            _layer.BackgroundColor = color.ToUIColor();
        }

        void BringLayer()
        {
            _layer.Layer.RemoveAllAnimations();
            _layer.Alpha = _alpha;
            View.BringSubviewToFront(_layer);
        }

        void EndAnimation()
        {
            if (!IsDisposed && _layer != null)
            {
                _layer.Layer.RemoveAllAnimations();
                UIView.Animate(0.225,
                () => {
                    _layer.Alpha = 0;
                });
            }
        }

        #endregion
    }
}
