using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Views.Templates
{
    [Preserve(AllMembers = true)]
    public partial class CardItemView : ContentView
    {
        #region Bindable Properties

        /// <summary>
        /// Bindable property for <see cref="Icon"/>
        /// </summary>
        public static readonly BindableProperty IconProperty =
             BindableProperty.Create(nameof(Icon), typeof(string), typeof(CardItemView), string.Empty);

        /// <summary>
        /// Bindable property for <see cref="FontIconFamily"/>
        /// </summary>
        public static readonly BindableProperty FontIconFamilyProperty =
             BindableProperty.Create(nameof(FontIconFamily), typeof(string), typeof(CardItemView), string.Empty);

        /// <summary>
        /// Bindable property for <see cref="IconColor"/>
        /// </summary>
        public static readonly BindableProperty IconColorProperty =
             BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(CardItemView), Color.White);

        /// <summary>
        /// Bindable property for <see cref="ItemValue"/>
        /// </summary>
        public static readonly BindableProperty ItemValueProperty =
             BindableProperty.Create(nameof(ItemValue), typeof(string), typeof(CardItemView), string.Empty);

        /// <summary>
        /// Bindable property for <see cref="ItemSelectedCommand"/>
        /// </summary>
        public static readonly BindableProperty ItemSelectedCommandProperty =
             BindableProperty.Create(nameof(ItemSelectedCommand), typeof(ICommand), typeof(CardItemView), null);

        #endregion

        #region Constructor

        public CardItemView()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the icon of the <see cref="CardItemView"/>.
        /// </summary>
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Gets or sets the icon's font family of the <see cref="CardItemView"/>.
        /// </summary>
        public string FontIconFamily
        {
            get { return (string)GetValue(FontIconFamilyProperty); }
            set { SetValue(FontIconFamilyProperty, value); }
        }

        /// <summary>
        /// Gets or sets the icon's color of the <see cref="CardItemView"/>.
        /// </summary>
        public Color IconColor
        {
            get { return (Color)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        /// <summary>
        /// Gets or sets the actual value of the <see cref="CardItemView"/>.
        /// </summary>
        public string ItemValue
        {
            get { return (string)GetValue(ItemValueProperty); }
            set { SetValue(ItemValueProperty, value); }
        }

        /// <summary>
        /// Gets or sets the command when the <see cref="CardItemView"/> is tapped.
        /// </summary>
        public ICommand ItemSelectedCommand
        {
            get { return (ICommand)GetValue(ItemSelectedCommandProperty); }
            set { SetValue(ItemSelectedCommandProperty, value); }
        }

        #endregion
    }
}
