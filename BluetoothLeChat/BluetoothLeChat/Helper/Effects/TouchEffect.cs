using System;
using System.Linq;
using BluetoothLeChat.Constants;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Helper.Effects
{
    [Preserve(AllMembers = true)]
    public static class TouchEffect
    {
        #region Attached Properties

        public static readonly BindableProperty ColorProperty =
            BindableProperty.CreateAttached(
              nameof(Color),
              typeof(Color),
              typeof(TouchEffect),
              Color.Default,
              propertyChanged: PropertyChanged
          );


        #endregion

        #region Properties

        public static void SetColor(BindableObject view, Color value)
        {
            view.SetValue(ColorProperty, value);
        }

        public static Color GetColor(BindableObject view)
        {
            return (Color)view.GetValue(ColorProperty);
        }

        #endregion

        #region Callback Methods

        static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is View view))
            {
                return;
            }

            var eff = view.Effects.FirstOrDefault(e => e is TouchRoutingEffect);
            if (GetColor(bindable) != Color.Default)
            {
                view.InputTransparent = false;

                if (eff != null) return;

                view.Effects.Add(new TouchRoutingEffect());

                if (EffectsConfig.AutoChildrenInputTransparent && bindable is Layout &&
                    !EffectsConfig.GetChildrenInputTransparent(view))
                {
                    EffectsConfig.SetChildrenInputTransparent(view, true);
                }
            }
            else
            {
                if (eff == null || view.BindingContext == null) return;

                view.Effects.Remove(eff);

                if (EffectsConfig.AutoChildrenInputTransparent && bindable is Layout &&
                    EffectsConfig.GetChildrenInputTransparent(view))
                {
                    EffectsConfig.SetChildrenInputTransparent(view, false);
                }
            }
        }

        #endregion
    }

    [Preserve(AllMembers = true)]
    public class TouchRoutingEffect : RoutingEffect
    {
        #region Constructor

        public TouchRoutingEffect() : base(AppConstants.TouchEffect)
        {

        }

        #endregion
    }
}
