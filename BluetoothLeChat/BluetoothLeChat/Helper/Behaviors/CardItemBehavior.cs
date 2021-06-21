using System;
using System.Windows.Input;
using BluetoothLeChat.Helper.Effects;
using BluetoothLeChat.Views.Templates;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Helper.Behaviors
{
	[Preserve(AllMembers = true)]
	public class CardItemBehavior : BehaviorBase<CardItemView>
	{
		#region Bindable Properties

		public static readonly BindableProperty EffectItemViewProperty =
				BindableProperty.Create(nameof(EffectItemView), typeof(View),
				typeof(CardItemBehavior), null);

		#endregion

		#region Constructor

		public CardItemBehavior()
		{

		}

		#endregion

		#region Properties

		public View EffectItemView
		{
			get { return (View)GetValue(EffectItemViewProperty); }
			set { SetValue(EffectItemViewProperty, value); }
		}

		#endregion

		#region Override Methods

		protected override void OnAttachedTo(CardItemView bindable)
		{
			base.OnAttachedTo(bindable);
			SubscribeEffectCommands(bindable);
		}

		#endregion

		#region Private Methods

		void SubscribeEffectCommands(CardItemView itemView)
		{
			//For Tapped
			EffectCommand.SetTap(EffectItemView, new Command(() =>
			{
				ExecuteCommand(itemView.ItemSelectedCommand, itemView.ItemSelectedCommandParameter);
			}));

			//For Long Pressed
			EffectCommand.SetLongTap(EffectItemView, new Command(() =>
			{
				ExecuteCommand(itemView.ItemSelectedCommand, itemView.ItemSelectedCommandParameter);
			}));
		}

		void ExecuteCommand(ICommand command, object parameter)
		{
			if (command?.CanExecute(parameter) ?? false)
			{
				command.Execute(parameter);
			}
		}

		#endregion
	}
}
