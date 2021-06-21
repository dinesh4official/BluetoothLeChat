using System;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Helper.Behaviors
{
	[Preserve(AllMembers = true)]
	public class BehaviorBase<T> : Behavior<T> where T : BindableObject
	{
		#region Property

		public T AssociatedObject { get; private set; }

		#endregion

		#region Override Methods

		protected override void OnAttachedTo(T bindable)
		{
			base.OnAttachedTo(bindable);
			AssociatedObject = bindable;

			if (bindable.BindingContext != null)
			{
				BindingContext = bindable.BindingContext;
			}

			bindable.BindingContextChanged += OnBindingContextChanged;
		}

		protected override void OnDetachingFrom(T bindable)
		{
			base.OnDetachingFrom(bindable);
			bindable.BindingContextChanged -= OnBindingContextChanged;
			AssociatedObject = null;
		}

		void OnBindingContextChanged(object sender, EventArgs e)
		{
			OnBindingContextChanged();
		}

		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			BindingContext = AssociatedObject.BindingContext;
		}

		#endregion
	}
}
