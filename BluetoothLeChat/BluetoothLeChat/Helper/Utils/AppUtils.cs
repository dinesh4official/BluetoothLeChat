using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BluetoothLeChat.Helper.Enum;
using BluetoothLeChat.ViewModels;
using BluetoothLeChat.Views;
using BluetoothLeCore.Interface;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace BluetoothLeChat.Helper.Utils
{
    [Preserve(AllMembers = true)]
    public static class AppUtils
    {
        #region Public Methods

        public static void ShowAlert(string message, bool isLong)
        {
            if (isLong)
            {
                DependencyService.Get<IMessage>().LongAlert(message);
            }
            else
            {
                DependencyService.Get<IMessage>().ShortAlert(message);
            }
        }

        public static void ChangeBLEStatus(bool needToEnable)
        {
            if (needToEnable)
            {
                DependencyService.Get<IBluetoothService>().EnableBluetooth();
            }
            else
            {
                DependencyService.Get<IBluetoothService>().DisableBluetooth();
            }
        }

        public static Color GetResourceValueAsColor(string resourceName)
        {
            return (Color)Application.Current.Resources[resourceName];
        }

        public static async void PushAsync(ContentPage contentPage)
        {
            await Application.Current.MainPage.Navigation.PushAsync(contentPage);
        }

        public static BasePage GetPageFromRoute(AppRoute appRoute, BaseViewModel viewModel = null)
        {
            BasePage basePage;
            switch(appRoute)
            {
                case AppRoute.BluetoothList:
                    basePage = new BluetoothListPage();
                    break;
                default:
                    basePage = new DashboardPage();
                    break;
            }

            if(viewModel != null)
            {
                basePage.BindingContext = viewModel;
            }

            return basePage;
        }

        public static IEnumerable<T> ToList<T>(this IEnumerable itemsSource)
        {
            foreach (var item in itemsSource)
            {
                yield return (T)item;
            }
        }

        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ObservableCollection<T>(enumerable);
        }

        #endregion
    }
}
