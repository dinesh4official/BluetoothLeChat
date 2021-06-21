using System;
using System.Linq;
using System.Windows.Input;
using BluetoothLeChat.Constants;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Helper.Effects
{
    [Preserve(AllMembers = true)]
    public static class EffectCommand
    {
        #region Bindable Properties

        public static readonly BindableProperty TapProperty =
            BindableProperty.CreateAttached(
                AppConstants.Tap,
                typeof(ICommand),
                typeof(EffectCommand),
                default(ICommand),
                propertyChanged: PropertyChanged
            );

        public static readonly BindableProperty TapParameterProperty =
           BindableProperty.CreateAttached(
               AppConstants.TapParameter,
               typeof(object),
               typeof(EffectCommand),
               default(object),
               propertyChanged: PropertyChanged
           );

        public static readonly BindableProperty LongTapProperty =
           BindableProperty.CreateAttached(
               AppConstants.LongTap,
               typeof(ICommand),
               typeof(EffectCommand),
               default(ICommand),
               propertyChanged: PropertyChanged
           );

        public static readonly BindableProperty LongTapParameterProperty =
            BindableProperty.CreateAttached(
                AppConstants.LongTapParameter,
                typeof(object),
                typeof(EffectCommand),
                default(object)
            );


        #endregion

        #region Attached Properties

        public static void SetTap(BindableObject view, ICommand value)
        {
            view.SetValue(TapProperty, value);
        }

        public static ICommand GetTap(BindableObject view)
        {
            return (ICommand)view.GetValue(TapProperty);
        }

        public static void SetTapParameter(BindableObject view, object value)
        {
            view.SetValue(TapParameterProperty, value);
        }

        public static object GetTapParameter(BindableObject view)
        {
            return view.GetValue(TapParameterProperty);
        }

        public static void SetLongTap(BindableObject view, ICommand value)
        {
            view.SetValue(LongTapProperty, value);
        }

        public static ICommand GetLongTap(BindableObject view)
        {
            return (ICommand)view.GetValue(LongTapProperty);
        }

        public static void SetLongTapParameter(BindableObject view, object value)
        {
            view.SetValue(LongTapParameterProperty, value);
        }

        public static object GetLongTapParameter(BindableObject view)
        {
            return view.GetValue(LongTapParameterProperty);
        }

        #endregion

        #region Callback Methods

        static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (!(bindable is View view))
                return;

            var effect = view.Effects.FirstOrDefault(e => e is CommandsRoutingEffect);

            if (GetTap(bindable) != null || GetLongTap(bindable) != null)
            {
                view.InputTransparent = false;

                if (effect != null) { return; }

                view.Effects.Add(new CommandsRoutingEffect());

                if (EffectsConfig.AutoChildrenInputTransparent && bindable is Layout &&
                    !EffectsConfig.GetChildrenInputTransparent(view))
                {
                    EffectsConfig.SetChildrenInputTransparent(view, true);
                }
            }
            else
            {
                if (effect == null || view.BindingContext == null) { return; }

                view.Effects.Remove(effect);

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
    public class CommandsRoutingEffect : RoutingEffect
    {
        #region Constructor

        public CommandsRoutingEffect() : base(AppConstants.EffectCommand)
        {

        }

        #endregion
    }
}
