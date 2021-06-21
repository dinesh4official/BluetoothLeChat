using System;
using BluetoothLeChat.Constants;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Helper.Effects
{
    [Preserve(AllMembers = true)]
    public static class EffectsConfig
    {
        #region Attached Properties

        public static readonly BindableProperty ChildrenInputTransparentProperty =
          BindableProperty.CreateAttached(
              AppConstants.ChildrenInputTransparent,
              typeof(bool),
              typeof(EffectsConfig),
              false,
              propertyChanged: (bindable, oldValue, newValue) => {
                  ConfigureChildrenInputTransparent(bindable);
              }
          );

        #endregion

        #region Properties

        public static bool AutoChildrenInputTransparent { get; set; } = true;

        public static void SetChildrenInputTransparent(BindableObject view, bool value)
        {
            view.SetValue(ChildrenInputTransparentProperty, value);
        }

        public static bool GetChildrenInputTransparent(BindableObject view)
        {
            return (bool)view.GetValue(ChildrenInputTransparentProperty);
        }

        #endregion

        #region Callback Methods

        static void ConfigureChildrenInputTransparent(BindableObject bindable)
        {
            if (!(bindable is Layout layout))
                return;

            if (GetChildrenInputTransparent(bindable))
            {
                foreach (var layoutChild in layout.Children)
                {
                    AddInputTransparentToElement(layoutChild);
                }

                layout.ChildAdded += Layout_ChildAdded;
            }
            else
            {
                layout.ChildAdded -= Layout_ChildAdded;
            }
        }

        static void Layout_ChildAdded(object sender, ElementEventArgs e)
        {
            AddInputTransparentToElement(e.Element);
        }

        #endregion

        #region Private Methods

        static void AddInputTransparentToElement(BindableObject obj)
        {
            if (obj is View view && TouchEffect.GetColor(view) == Color.Default && EffectCommand.GetTap(view) == null && EffectCommand.GetLongTap(view) == null)
            {
                view.InputTransparent = true;
            }
        }

        #endregion
    }
}
