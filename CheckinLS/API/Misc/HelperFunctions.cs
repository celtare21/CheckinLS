﻿using Acr.UserDialogs;
using Microsoft.AppCenter.Analytics;
using System;
using System.Globalization;
using System.Threading.Tasks;
using CheckinLS.API.Sql;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckinLS.API.Misc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public static class HelperFunctions
    {
        public static string ConversionWrapper<T>(T elem)
        {
            return elem switch
            {
                int i => i.ToString(),
                string str => str,
                DateTime time => time.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                TimeSpan span => span.ToString(@"hh\:mm"),
                var _ => throw new ArgumentException()
            };
        }

        public static Task ShowAlertAsync(string message, bool kill) =>
            Device.InvokeOnMainThreadAsync(async () =>
            {
                Analytics.TrackEvent(message);
                await Application.Current.MainPage.DisplayAlert("Error", message, "OK");
                if (kill)
                    App.Close();
            });

        public static Task ShowToastAsync(string message) =>
            Device.InvokeOnMainThreadAsync(() =>
                UserDialogs.Instance.Toast(message));

        public static string RemoveWhitespace(this string str) =>
            string.Join(string.Empty, str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));

        public static DateTime SubstractMonths(this DateTime date, int value) =>
            date.AddMonths(-value);

        public static async Task<bool> InternetCheck()
        {
            if (await MainSql.CkeckConnectionAsync())
                return true;

            await ShowAlertAsync("No internet connection!", true);
            return false;
        }
    }
}
