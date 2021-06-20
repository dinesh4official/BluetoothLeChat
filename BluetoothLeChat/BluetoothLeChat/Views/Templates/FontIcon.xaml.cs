using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Views.Templates
{
    [Preserve(AllMembers = true)]
    public partial class FontIcon : Label
    {
        #region Bindable Properties

        /// <summary>
        /// Bindable property for <see cref="Icon"/>
        /// </summary>
        public static readonly BindableProperty IconProperty =
             BindableProperty.Create(nameof(Icon), typeof(string), typeof(FontIcon), string.Empty);

        /// <summary>
        /// Bindable property for <see cref="IconFontFamily"/>
        /// </summary>
        public static readonly BindableProperty FontIconFamilyProperty =
             BindableProperty.Create(nameof(FontIconFamily), typeof(string), typeof(FontIcon), string.Empty);

        /// <summary>
        /// Bindable property for <see cref="IconColor"/>
        /// </summary>
        public static readonly BindableProperty IconColorProperty =
             BindableProperty.Create(nameof(IconColor), typeof(Color), typeof(FontIcon), Color.White);

        #endregion

        #region Constructor

        public FontIcon()
        {
            InitializeComponent();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the icon of the <see cref="FontIcon"/>.
        /// </summary>
        public string Icon
        {
            get { return (string)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        /// <summary>
        /// Gets or sets the icon's font family of the <see cref="FontIcon"/>.
        /// </summary>
        public string FontIconFamily
        {
            get { return (string)GetValue(FontIconFamilyProperty); }
            set { SetValue(FontIconFamilyProperty, value); }
        }

        /// <summary>
        /// Gets or sets the icon's color of the <see cref="FontIcon"/>.
        /// </summary>
        public Color IconColor
        {
            get { return (Color)GetValue(IconColorProperty); }
            set { SetValue(IconColorProperty, value); }
        }

        #endregion
    }
}
